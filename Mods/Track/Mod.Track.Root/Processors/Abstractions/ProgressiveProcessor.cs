using System.Collections.Concurrent;
using ParallelProcessing.Contexts;
using ParallelProcessing.Models.Items.Base;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Processors.Abstractions;

public abstract class ProgressiveProcessor<TInput, TProcessionResult>(
    IEventLoggingService? loggingService,
    string processorName)
    : IProgressiveProcessor<TInput>
    where TInput : ApplicationItem<string>
    where TProcessionResult : IProcessionResult
{
    #region private fields

    private readonly IEventLoggingService? LoggingService = loggingService;

    private readonly ParallelProcessionSynchronizationService<TInput> _parallelProcessionSynchronizationService = new(loggingService);

    #endregion

    #region Public Properties

    public ConcurrentStack<IProgressiveProcessor<TInput>> ProcessorsExecuting { get; set; } = new();

     public SemaphoreSlim SemaphoreSlim { get; } = new (1, 1);

    public int DependentProcessorsExecutingCount { get; set; }

    public ConcurrentQueue<IProgressiveProcessor<TInput>> DependedProcessors { get; set; } = new();
    
    public bool IsRoot { get; set; }
    
    public bool IsDependantRoot { get; set; }

    public int TotalAmountOfProcessors { get; set; } = 1;

    public string ProcessorTypeName { get; set; }
    public string ProcessorName { get; set; } = processorName;

    public bool IsCompletedNestedProcessing { get;  }

    public int InitialAmountOfNotExecutedDependantProcessors {get; set; }

    public bool IsCompletedSelfProcessing { get; set; }

    public bool IsStartedSelfProcessing { get; set;}
    public bool IsSomeOfNestedRootsProcessingCompletedEventFired { get; set; }
    
    public bool GotDependentProcessorsExecutingCountFromDependentRoot { get; set; }
    
    public IProgressiveProcessor<TInput>? RootProcessorFromDependentQueue { get; set; }
    public IProgressiveProcessor<TInput>? ParentProcessor { get; set; }
    
    public ConcurrentQueue<IProgressiveProcessor<TInput>>? RootsFromDependantQueuePool { get; } = new ();

    #endregion

    #region Events

    public event Func<Task> NestedProcessingCompletedEvent;
    public event Func<Task> DependantProcessorWasDequeuedEvent;
    public event Func<Task> SomeOfNestedRootsProcessingCompletedEvent;
    public event Func<Task> CurrentProcessingCompletedEvent;
    
    #endregion

    #region Protected Abstract Methods

    protected abstract Task<IProcessionResult> ProcessLogic(TInput inputData);
    
    protected abstract Task SetProcessionResult(TProcessionResult result);

    #endregion

    #region Public Methods

    public async Task ProcessNextAsync(TInput inputData)
    {
        await _parallelProcessionSynchronizationService.WaitLockWithCallback(this, DoConditionalProcession, inputData);
    }

    public async Task DoConditionalProcession(TInput inputData)
    {
        var isCurrentTreadForCompletedRoot = IsStartedSelfProcessing && IsCompletedSelfProcessing && IsRoot;
        var isCurrentTreadForNotStartedExecutionRoot =
            !IsStartedSelfProcessing && !IsCompletedSelfProcessing && IsRoot;
        //This block executing only from other from root threads and
        //!!!there is No sense to set here something for Semaphore!!!
        if (!IsRoot)
        {
            IsStartedSelfProcessing = true;
            // this.CurrentProcessingCompletedEvent +=  async () => await SignalSomeOfNestedRootsProcessingCompletedEvent();
            // RecursivelySubscribeRootProcessorCompletedEventParent(this, this.ParentProcessor);
            await ProcessLogicAndComplete(inputData);
            IsCompletedSelfProcessing = true;
            return;
        }
        
                
        //This block Executing in Root thread and only in case Root is Never Called
        //So it executing once for root
        if (isCurrentTreadForNotStartedExecutionRoot)
        {
            await ProcessLogicForRootBeforeStartCallingDependencies(inputData);
            return;
        }

        
        //This block Executing in Root thread and only in case Root is fully completed
        if (isCurrentTreadForCompletedRoot)
        {
            await CheckAndProcessDependentProcessorOrDependantRoot(inputData);
        }
    }

    public void AddDependentProcessor(IProgressiveProcessor<TInput> dependentProcessor)
    {
        ProcessorTypeName = this.GetType().FullName;
        dependentProcessor.ProcessorTypeName = dependentProcessor.GetType().FullName;
        // if (DependedProcessors.TryPeek(out var lastDependantInParent))
        // {
        //     lastDependantInParent.IsHaveToPassNextRoot = true;
        // }

        DependedProcessors.Enqueue(dependentProcessor);

        TotalAmountOfProcessors++;
        DependentProcessorsExecutingCount++;
        InitialAmountOfNotExecutedDependantProcessors ++;
        IncrementParentsTotalCount(1, ParentProcessor);
        this.IsRoot = true;

        dependentProcessor.ParentProcessor = this;
    }

    public event Func<TInput, Task>? ParentProcessingCompletedEvent;

    public int IncrementParentsTotalCount(int count, IProgressiveProcessor<TInput> parentProcessor)
    {
        if (parentProcessor != null)
        {
            parentProcessor.TotalAmountOfProcessors += count;
            return parentProcessor.IncrementParentsTotalCount(count, parentProcessor.ParentProcessor);
        }

        return TotalAmountOfProcessors;
    }

    public int DecrementParentsTotalCount(int count, IProgressiveProcessor<TInput> parentProcessor)
    {

        if (parentProcessor != null)
        {
            parentProcessor.DecrementParentsTotalCount(count, parentProcessor.ParentProcessor);
            parentProcessor.TotalAmountOfProcessors -= count;
        }
        
        // TotalAmountOfProcessors -= count;
        

        return TotalAmountOfProcessors;
    }
    
    public void SetDependents(ConcurrentQueue<IProgressiveProcessor<TInput>> dependents)
    {
        this.IsRoot = true;
        DependedProcessors = dependents;
        TotalAmountOfProcessors += dependents.Count;
        InitialAmountOfNotExecutedDependantProcessors += dependents.Count;
        IncrementParentsTotalCount(dependents.Count, ParentProcessor);
    }

    public async Task SignalNestedProcessingCompletionEvent()
    {
        if (NestedProcessingCompletedEvent != null)
            await NestedProcessingCompletedEvent?.Invoke();
    }

    public async Task SignalDependantProcessorWasDequeuedEvent()
    {
        if (DependantProcessorWasDequeuedEvent != null)
            await DependantProcessorWasDequeuedEvent?.Invoke();
    }

    public async Task SignalSomeOfNestedRootsProcessingCompletedEvent()
    {
        if (SomeOfNestedRootsProcessingCompletedEvent != null)
        {
            await SomeOfNestedRootsProcessingCompletedEvent?.Invoke();
            IsSomeOfNestedRootsProcessingCompletedEventFired = true;
        }

        if (ParentProcessor != null)
        {
            await ParentProcessor.SignalDependantProcessorWasDequeuedEvent();
        }
    }
    
    public void RecursivelySetRootProcessorForDependentQueueToParent(IProgressiveProcessor<TInput> processor, IProgressiveProcessor<TInput> parentProcessor)
    {
        if (processor.IsRoot && parentProcessor == null)
        {
            return;
        }
        if (parentProcessor?.ParentProcessor == null)
        {
            parentProcessor.RootProcessorFromDependentQueue = processor;
            return;
        }
        if (parentProcessor != null)
        {
            RecursivelySetRootProcessorForDependentQueueToParent(processor, parentProcessor.ParentProcessor);
            return;
        }
    }
    
    public void RecursivelySetRootProcessorForDependentQueuePoolToParent(IProgressiveProcessor<TInput> processor, IProgressiveProcessor<TInput> parentProcessor)
    {
        if (processor.IsRoot && parentProcessor == null)
        {
            return;
        }
        if (parentProcessor?.ParentProcessor == null)
        {
            parentProcessor.RootsFromDependantQueuePool.Enqueue(processor);
            processor.IsDependantRoot = true;
            
            return;
        }
        if (parentProcessor != null)
        {
            RecursivelySetRootProcessorForDependentQueuePoolToParent(processor, parentProcessor.ParentProcessor);
            return;
        }
    }
    
    public void RecursivelySubscribeRootProcessorCompletedEventParent(IProgressiveProcessor<TInput> processor, IProgressiveProcessor<TInput> parentProcessor)
    {
        if (processor.IsRoot && parentProcessor == null)
        {
            return;
        }
        if (parentProcessor?.ParentProcessor == null)
        {
            parentProcessor.IsSomeOfNestedRootsProcessingCompletedEventFired = false;
            // processor.CurrentProcessingCompletedEvent += async () => await parentProcessor
            //     .SignalSomeOfNestedRootsProcessingCompletedEvent();
            // parentProcessor.SomeOfNestedRootsProcessingCompletedEvent+= async () => await SignalSomeOfNestedRootsProcessingCompletedEvent();
            
            parentProcessor.GotDependentProcessorsExecutingCountFromDependentRoot = false;
            return;
        }
        if (parentProcessor != null)
        {
            RecursivelySetRootProcessorForDependentQueuePoolToParent(processor, parentProcessor.ParentProcessor);
            return;
        }
    }

    #endregion
    
    #region Private Methods

    private async Task ProcessLogicForRootBeforeStartCallingDependencies(TInput inputData)
    {
        //Here we check Dependents and set ProcessorsExecutingCount for avoid LOCK
        // if (DependedProcessors.Any())
        // {
        //     DependentProcessorsExecutingCount = DependedProcessors.Count;
        // }

        //Here we just ProcessLogic because it root for some Dependencies
        
   
        // this.CurrentProcessingCompletedEvent +=  async () => await SignalSomeOfNestedRootsProcessingCompletedEvent();
        RecursivelySubscribeRootProcessorCompletedEventParent(this, this.ParentProcessor);
        await ProcessLogicAndComplete(inputData);
        RecursivelySetRootProcessorForDependentQueuePoolToParent(this, this.ParentProcessor);
    }

    private async Task CheckAndProcessDependentProcessorOrDependantRoot(TInput inputData)
    {
        var nextInQueueProcessor = GetNextProcessorFromDependants();

        // IF   root processor than was  set from queue during parallel execution, then  execute it 
        // if (RootsFromDependantQueuePool.TryTake(out var rootProcessorFromPool))
        // {
        //     await rootProcessorFromPool.DoConditionalProcession(inputData);
        //     if (rootProcessorFromPool.DependedProcessors.TryPeek(out var pp))
        //     {
        //         RootsFromDependantQueuePool.Add(rootProcessorFromPool);
        //     }
        //     
        //     return;
        // }
        if (RootProcessorFromDependentQueue != null && RootProcessorFromDependentQueue != this)
        {
            await RootProcessorFromDependentQueue.DoConditionalProcession(inputData);
            // if (RootProcessorFromDependentQueue.DependedProcessors.Count > 0)
            // {
            //     RecursivelySetRootProcessorForDependentQueuePoolToParent(RootProcessorFromDependentQueue, ParentProcessor);
            // }
            return;
        }
        
        // if (RootProcessorFromDependentQueue != null && 
        //          nextInQueProcessor == null)
        // {
        //     if (nextInQueProcessor != null)
        //     {
        //         RootProcessorFromDependentQueue.IsHaveToPassNextRoot = true;
        //         RootsFromDependantQueuePool.Add(nextInQueProcessor);
        //     }
        //     await RootProcessorFromDependentQueue.DoConditionalProcession(inputData);
        //     // RootProcessorFromDependentQueue.IsHaveToPassNextRoot = false;
        //     // if (RootProcessorFromDependentQueue.DependedProcessors.TryPeek(out var dp) && dp.IsRoot)
        //     // {
        //     //     RootsFromDependantQueuePool.Add(dp);
        //     // }
        //     return;
        // }

        // if (RootProcessorFromDependentQueue != this && RootProcessorFromDependentQueue != null)
        // {
        //     await RootProcessorFromDependentQueue.DoConditionalProcession(inputData);
        //     return;
        // }

        //If we dont have root processor set from queue and remain in queue processors => Then we execute queue processor
        if (nextInQueueProcessor != null)
        {
            // if (DependedProcessors.TryPeek(out var nextInQueueProcessorAfter) && nextInQueueProcessorAfter.IsRoot)
            // {
            //     nextInQueueProcessor.IsHaveToPassNextRoot = true;
            // }
            // InitialAmountOfNotExecutedDependantProcessors --;
            await nextInQueueProcessor.DoConditionalProcession(inputData);

        }
    }


    private IProgressiveProcessor<TInput>? GetNextProcessorFromDependants()
    {
        DependedProcessors.TryDequeue(out IProgressiveProcessor<TInput>? proc);
        
        return proc;
    }

    private async Task ProcessLogicAndComplete(TInput input)
    {
        IsStartedSelfProcessing = true;
        var countOfDependants = DependedProcessors.Count;
        if(ParentProcessor == null && IsRoot && RootProcessorFromDependentQueue != null){
            countOfDependants = RootProcessorFromDependentQueue.DependedProcessors.Count;
        }

        var processionResult =  await ProcessLogic(input);
        
        
        IsCompletedSelfProcessing = true;

        if (ParentProcessor != null)
        {
            await SemaphoreSlim.WaitAsync();
            try
            {
                ParentProcessor.InitialAmountOfNotExecutedDependantProcessors--;
                if (ParentProcessor.InitialAmountOfNotExecutedDependantProcessors == 0)
                {
                    await ParentProcessor.SignalSomeOfNestedRootsProcessingCompletedEvent();
                }
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        CurrentProcessingCompletedEvent?.Invoke();
        var totalCount = DecrementParentsTotalCount(1, this.ParentProcessor);
        if (totalCount == 0)
        {
            
        }
        
        TotalAmountOfProcessors--;
    }

    #endregion


    #region Event Handlers

    private async Task ProcessorFromDependentQueOnCurrentProcessingCompletedEventHandler(IProgressiveProcessor<TInput> processor)
    {
        await LoggingService.Log(
            $"ProcessorFromDependentQueOnCurrentProcessingCompletedEventHandler on {this.ProcessorTypeName}",
            EventLoggingTypes.HandlingEvent, processor.ProcessorTypeName);
    }

    private async Task NestedProcessingCompletedEventHandler()
    {
        // await LoggingService.Log("NestedProcessingCompletedEventHandler", EventLoggingTypes.);
    }

    #endregion
}