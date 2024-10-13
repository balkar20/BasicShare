using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Contexts;

public class ParallelProcessionSynchronizationService<TInput>(IEventLoggingService? loggingService)
{
    #region Constants

    const string HimselfLabel = "Himself";

    #endregion
    
    #region Fields
    
    private int _counter;
    private int  oldCount = 0;
    private int  newCount = 0;
    private int _counterOfCurrentlyExecutingDependentRoots = 0;
    private bool _completionWasFired;
    private bool _isTopRootExecuting;

    #endregion

    #region Properties
    
    public SemaphoreSlim SemaphoreSlim { get; } = new (1, 1);
    
    #endregion
    
    #region Public Methods

    public async Task WaitLockWithCallback(IProgressiveProcessor<TInput> rootProcessor, Func< TInput, Task> callback, TInput input)
    {
        var (executionName, acquireId) = await AcquireAndLog(rootProcessor);
        
        var dependentProcessorExists = rootProcessor.DependedProcessors.TryPeek(out var dependantProcessor);

        _isTopRootExecuting = (!rootProcessor.IsStartedSelfProcessing ||
                               (rootProcessor.IsStartedSelfProcessing && 
                                rootProcessor.IsCompletedSelfProcessing &&
                                dependantProcessor != null &&
                                (!dependantProcessor.IsRoot || !dependantProcessor.IsStartedSelfProcessing))) &&
                                  dependentProcessorExists;
        
        bool isNeedToKeepLockedUntilDependentRootReleased =
            CheckIsNeedToKeepLockedUntilDependentRootReleased(
                rootProcessor.RootProcessorFromDependentQueue == null ?
                rootProcessor : 
                rootProcessor.RootProcessorFromDependentQueue, false);
        var countOfDependentRootsInPool = rootProcessor?.RootsFromDependantQueuePool?.Count;

        if (countOfDependentRootsInPool > 0 && 
             dependantProcessor == null &&
             GetDependantExecutingCount(rootProcessor) == 0 && 
             rootProcessor.RootsFromDependantQueuePool.TryDequeue(out var executingRootProcessor))
        {
            
            if (rootProcessor.RootProcessorFromDependentQueue != executingRootProcessor)
            {
                
                rootProcessor.RootProcessorFromDependentQueue = executingRootProcessor;
                isNeedToKeepLockedUntilDependentRootReleased =
                    CheckIsNeedToKeepLockedUntilDependentRootReleased(executingRootProcessor, false) ;
            }
            _counterOfCurrentlyExecutingDependentRoots = rootProcessor.RootsFromDependantQueuePool.Count;
        }
        try
        {
            if (GetDependantExecutingCount(rootProcessor) > 0 && !isNeedToKeepLockedUntilDependentRootReleased)
            {
                var remainCountToExecuteInThisHierarchyLevel = DecrementDependantExecutingCount(rootProcessor);
                if (remainCountToExecuteInThisHierarchyLevel == 0)
                {
                    await SubscribeForCurrentLevelExecution(rootProcessor, acquireId, executionName);
                }
                else
                {
                    await LogAndRelease(acquireId, rootProcessor, executionName, true);
                }
            }
            await callback(input);
        }
        finally
        {
            if (isNeedToKeepLockedUntilDependentRootReleased)
            {
                await LogAndRelease(acquireId, rootProcessor, executionName);
            }
            await CheckAndHandleCompletion(rootProcessor);
        }
    }

    #endregion
    
    #region Private Methods
    
    private async Task CheckAndHandleCompletion(IProgressiveProcessor<TInput> rootProcessor)
    {
        if (_counter == 0 && rootProcessor.DependedProcessors.Count == 0 && !_completionWasFired)
        {
            _completionWasFired = true;
            await rootProcessor.SignalNestedProcessingCompletionEvent();
        }
    }
    
    private async Task<(string, int)> AcquireAndLog(IProgressiveProcessor<TInput> processor)
    {
        _counter++;
        await SemaphoreSlim.WaitAsync();

        var acquireId = new Random().Next(1, 10000);
        var dependentProcessorExists = processor.DependedProcessors.TryPeek(out var dependantProcessor);
        var rootCompleted = processor.IsStartedSelfProcessing && processor.IsCompletedSelfProcessing;
        var dependantExistsAndRootCompleted = dependentProcessorExists && rootCompleted;

        var dependantProcessorTypeName =
            dependantExistsAndRootCompleted ? dependantProcessor.ProcessorTypeName : HimselfLabel;
        
        await loggingService.Log($"Id = {acquireId} AcquireTime{DateTime.Now}, Name = {processor.ProcessorName}, TypeName = {processor.ProcessorTypeName} for {dependantProcessorTypeName}",
            EventLoggingTypes.SemaphoreAcquired, processor.RootProcessorFromDependentQueue?.ProcessorTypeName);
        return (dependantProcessorTypeName, acquireId);
    }
    
    private async Task LogAndRelease(int acquireId, IProgressiveProcessor<TInput> processor, string executionName, bool isExecutesAfterRelease = false)
    {
        var dependentProcessorExists = processor.DependedProcessors.TryPeek(out var dependantProcessor);
        var bufList =  processor.DependedProcessors.ToList();
        var dependantNames = GetElementNames(bufList);
        var executingAfterReleaseMessage = isExecutesAfterRelease ? $"Executing After Release With execution Dependencies: {dependantNames}" : "";
        var rootCompleted = processor.IsStartedSelfProcessing && processor.IsCompletedSelfProcessing;
        var dependantExistsAndRootCompleted = dependentProcessorExists && rootCompleted;
        var dependantExistsAndRootCompletedAndDependantNotCompleted = dependantExistsAndRootCompleted 
                                                                      && !dependantProcessor.IsCompletedSelfProcessing;
        
        var dependantProcessorTypeName =
            dependantExistsAndRootCompleted ? dependantProcessor.ProcessorTypeName : HimselfLabel;
        if (dependantExistsAndRootCompletedAndDependantNotCompleted)
        {
            dependantProcessorTypeName = HimselfLabel;
        }
        await loggingService.Log($"Id = {acquireId}, ReleaseTime{DateTime.Now}, Name = {processor.ProcessorName}, TypeName = {processor.ProcessorTypeName} , for {(dependentProcessorExists ? 
            dependantProcessorTypeName : 
            HimselfLabel)} {executingAfterReleaseMessage}" , EventLoggingTypes.SemaphoreReleased, executionName); 

        SemaphoreSlim.Release();
        _counter--;
    }
    
    private string GetElementNames(List<IProgressiveProcessor<TInput>> list)
    {
        return string.Join(", ", list.Select(obj => obj.ProcessorTypeName));
    }

    private bool CheckIsNeedToKeepLockedUntilDependentRootReleased(IProgressiveProcessor<TInput> processor, bool isFromRootDependant)
    {
        var dependentProcessorExists = processor.DependedProcessors.TryPeek(out var dependantProcessor);
        var dependentsCount = processor.DependedProcessors.Count;
        
        var isNeedToKeepLockedUntilDependentRootReleased =
            (dependentProcessorExists &&
            !processor.IsStartedSelfProcessing) ||
            (processor.IsStartedSelfProcessing &&
             processor.IsCompletedSelfProcessing &&
             dependentsCount == 0)
             || (processor.IsStartedSelfProcessing &&
               processor.IsCompletedSelfProcessing &&
               dependentsCount == 1 &&
               processor.IsDependantRoot);
        
        return isNeedToKeepLockedUntilDependentRootReleased;
    }

    private int GetDependantExecutingCount(IProgressiveProcessor<TInput> processor)
    {
        if (_isTopRootExecuting)
            return processor.DependentProcessorsExecutingCount;


        var rootProcessorFromDependentQueue = processor.RootProcessorFromDependentQueue;
        if (rootProcessorFromDependentQueue != null)
            return (rootProcessorFromDependentQueue.DependedProcessors.Count == 0 &&
            rootProcessorFromDependentQueue.IsCompletedSelfProcessing) ? 0 : rootProcessorFromDependentQueue.DependentProcessorsExecutingCount;
        return 0;
    }

    private int  DecrementDependantExecutingCount(IProgressiveProcessor<TInput> processor)
    {
        if (_isTopRootExecuting)
            return --processor.DependentProcessorsExecutingCount;

        if (processor.RootProcessorFromDependentQueue != null)
            return --processor.RootProcessorFromDependentQueue.DependentProcessorsExecutingCount;
        return 0;
    }
    
    private async Task SubscribeForCurrentLevelExecution(IProgressiveProcessor<TInput> rootProcessor, int acquireId, string executionName)
    {
        // if (_isTopRootExecuting || rootProcessor.RootProcessorFromDependentQueue != null)
        if (_isTopRootExecuting)
        {
            rootProcessor.SomeOfNestedRootsProcessingCompletedEvent  +=  async () => 
                await LogAndRelease(acquireId, rootProcessor, executionName, true);
            await CheckAndHandleCompletion(rootProcessor);
            
        }
    }
    
    #endregion
}