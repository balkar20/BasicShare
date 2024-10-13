using System.Collections.Concurrent;
using ParallelProcessing.Contexts;
using ParallelProcessing.Models.Items.Base;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Processors.Abstractions;

public abstract class FlatLadderProcessor<TInput, TProcessionResult>(
    IEventLoggingService? loggingService,
    string processorName)
    : IFlatLadderProcessor<TInput>
    where TInput : ApplicationItem<string>
    where TProcessionResult : IProcessionResult
{
    #region private fields

    private readonly IEventLoggingService? LoggingService = loggingService;

    private readonly FlatLadderParallelProcessionSynchronizationService<TInput> _parallelProcessionSynchronizationService = new(loggingService);

    #endregion

    #region Public Properties

    public ConcurrentStack<IFlatLadderProcessor<TInput>> ProcessorsExecuting { get; set; } = new();

    public int DependentProcessorsExecutingCount { get; set; }

    public ConcurrentQueue<IFlatLadderProcessor<TInput>> DependedProcessors { get; set; } = new();
    
    public bool IsRoot { get; set; }

    public int TotalAmountOfProcessors { get; set; } = 1;

    public string ProcessorTypeName { get; set; }
    public string ProcessorName { get; set; } = processorName;

    public bool IsCompletedNestedProcessing { get; set; }
    public bool IsCompletedCurrentProcessing { get; set; }

    public bool IsStartedSelfProcessing { get; set; }
    
    public bool GotDependentProcessorsExecutingCountFromDependentRoot { get; set; }
    
    public IFlatLadderProcessor<TInput>? RootProcessorFromDependentQueue { get; set; }
    public IFlatLadderProcessor<TInput>? ParentProcessor { get; set; }

    #endregion

    #region Events

    public event Func<Task> NestedProcessingCompletedEvent;
    public event Func<IFlatLadderProcessor<TInput>, int, Task> CurrentProcessingCompletedEvent;
    
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
        var isCurrentTreadForCompletedRoot = IsStartedSelfProcessing && IsCompletedCurrentProcessing && IsRoot;
        var isCurrentTreadForNotStartedExecutionRoot =
            !IsStartedSelfProcessing && !IsCompletedCurrentProcessing && IsRoot;
        //This block executing only from other from root threads and
        //!!!there is No sense to set here something for Semaphore!!!
        if (!IsRoot)
        {
            IsStartedSelfProcessing = true;
            await ProcessLogicAndComplete(inputData);
            IsCompletedCurrentProcessing = true;
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
            await CheckAndProcessDependentProcessor(inputData);
        }
    }

    public void AddDependentProcessor(IFlatLadderProcessor<TInput> dependentProcessor)
    {
        ProcessorTypeName = this.GetType().FullName;
        dependentProcessor.ProcessorTypeName = dependentProcessor.GetType().FullName;
        DependedProcessors.Enqueue(dependentProcessor);

        TotalAmountOfProcessors++;
        IncrementParentsTotalCount(1, ParentProcessor);
        this.IsRoot = true;
        dependentProcessor.ParentProcessor = this;
    }

    public event Func<TInput, Task>? ParentProcessingCompletedEvent;

    public int IncrementParentsTotalCount(int count, IFlatLadderProcessor<TInput> parentProcessor)
    {
        if (parentProcessor != null)
        {
            parentProcessor.TotalAmountOfProcessors += count;
            return parentProcessor.IncrementParentsTotalCount(count, parentProcessor.ParentProcessor);
        }

        return TotalAmountOfProcessors;
    }

    public int DecrementParentsTotalCount(int count, IFlatLadderProcessor<TInput> parentProcessor)
    {

        if (parentProcessor != null)
        {
            parentProcessor.TotalAmountOfProcessors -= count;
            return parentProcessor.DecrementParentsTotalCount(count, parentProcessor.ParentProcessor);
        }
        
        // TotalAmountOfProcessors -= count;
        

        return TotalAmountOfProcessors;
    }
    
    public void SetDependents(ConcurrentQueue<IFlatLadderProcessor<TInput>> dependents)
    {
        this.IsRoot = true;
        DependedProcessors = dependents;
        TotalAmountOfProcessors += dependents.Count;
        IncrementParentsTotalCount(dependents.Count, ParentProcessor);
    }

    public async Task SignalNestedProcessingCompletion()
    {
        await NestedProcessingCompletedEvent.Invoke();
    }

    #endregion


    #region Protected Methods

    #endregion


    #region Private Methods

    private async Task ProcessLogicForRootBeforeStartCallingDependencies(TInput inputData)
    {
        //Here we check Dependents and set ProcessorsExecutingCount for avoid LOCK
        if (DependedProcessors.Any())
        {
            DependentProcessorsExecutingCount = DependedProcessors.Count;
        }

        //Here we just ProcessLogic because it root for some Dependencies
        await ProcessLogicAndComplete(inputData);

        RecursivelySetParent(this, this.ParentProcessor);
    }

    public void RecursivelySetParent(IFlatLadderProcessor<TInput> processor, IFlatLadderProcessor<TInput> parentProcessor)
    {
        if (processor.IsRoot && parentProcessor == null)
        {
            return;
        }
        if (parentProcessor?.ParentProcessor == null)
        {
            parentProcessor.RootProcessorFromDependentQueue = processor;
            parentProcessor.GotDependentProcessorsExecutingCountFromDependentRoot = false;
            return;
        }
        if (parentProcessor != null)
        {
            RecursivelySetParent(processor, parentProcessor.ParentProcessor);
            return;
        }
       
    }

    private async Task CheckAndProcessDependentProcessor(TInput inputData)
    {
        var nextInQueProcessor = GetNextProcessorFromDependants();

        // IF   root processor than was  set from queue during parallel execution, then  execute it 
        if (RootProcessorFromDependentQueue != this && RootProcessorFromDependentQueue != null)
        {
            await RootProcessorFromDependentQueue.DoConditionalProcession(inputData);
            return;
        }

        //If we dont have root processor set from queue and remain in queue processors => Then we execute queue processor
        if (nextInQueProcessor != null)
        {
            await nextInQueProcessor.DoConditionalProcession(inputData);
        }
    }


    private IFlatLadderProcessor<TInput>? GetNextProcessorFromDependants()
    {
        DependedProcessors.TryDequeue(out IFlatLadderProcessor<TInput>? proc);

        return proc;
    }

    private async Task ProcessLogicAndComplete(TInput input)
    {
        IsStartedSelfProcessing = true;
        await ProcessLogic(input);
        IsCompletedCurrentProcessing = true;
        
        TotalAmountOfProcessors--;
        
        DecrementParentsTotalCount(1, this.ParentProcessor);
    }

    #endregion


    #region Event Handlers

    private async Task ProcessorFromDependentQueOnCurrentProcessingCompletedEventHandler(IFlatLadderProcessor<TInput> processor)
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