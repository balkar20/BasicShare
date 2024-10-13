using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Contexts;

public class FlatLadderParallelProcessionSynchronizationService<TInput>(IEventLoggingService? loggingService)
{
    #region Constants

    const string HimselfLabel = "Himself";

    #endregion
    
    #region Fields
    
    private int _counter;
    private bool _completionWasFired;

    #endregion

    #region Properties
    
    public SemaphoreSlim SemaphoreSlim { get; } = new (1, 1);
    
    #endregion
    
    #region Public Methods

    public async Task WaitLockWithCallback(IFlatLadderProcessor<TInput> rootProcessor, Func< TInput, Task> callback, TInput input)
    {
        var (executionName, acquireId) = await AcquireAndLog(rootProcessor);
        
        var dependentProcessorExists = rootProcessor.DependedProcessors.TryPeek(out var dependantProcessor);

        var isNeedToKeepLock = !rootProcessor.IsStartedSelfProcessing &&
                               rootProcessor.IsRoot &&
                               dependentProcessorExists;
        bool isNeedToKeepLockedUntilDependentRootReleased =
            CheckIsNeedToKeepLockedUntilDependentRootReleased(rootProcessor) ||
            CheckIsNeedToKeepLockedUntilDependentRootReleased(rootProcessor.RootProcessorFromDependentQueue);
        

        if (dependantProcessor == null &&
            !rootProcessor.GotDependentProcessorsExecutingCountFromDependentRoot &&
            rootProcessor.RootProcessorFromDependentQueue?.DependedProcessors.Count > 0 &&
            rootProcessor.RootProcessorFromDependentQueue.IsCompletedCurrentProcessing &&
            !rootProcessor.RootProcessorFromDependentQueue.IsCompletedNestedProcessing)
        {
            rootProcessor.DependentProcessorsExecutingCount =
                rootProcessor.RootProcessorFromDependentQueue.DependentProcessorsExecutingCount;
            rootProcessor.GotDependentProcessorsExecutingCountFromDependentRoot = true;
        }
        try
        {
            if (rootProcessor.DependentProcessorsExecutingCount > 0 && !isNeedToKeepLockedUntilDependentRootReleased)
            {
                rootProcessor.DependentProcessorsExecutingCount --;
                await LogAndRelease(acquireId, rootProcessor, executionName, true);
            }
            await callback(input); 
            await CheckAndHandleCompletion(rootProcessor);
        }
        finally
        {
            if (isNeedToKeepLock)
            {
                await LogAndRelease(acquireId, rootProcessor, executionName);
            }
            else if (isNeedToKeepLockedUntilDependentRootReleased)
            {
                rootProcessor.DependentProcessorsExecutingCount--;
                await LogAndRelease(acquireId, rootProcessor, executionName);
            }
        }
    }
    
    #endregion
    
    #region Private Methods
    
    private async Task CheckAndHandleCompletion(IFlatLadderProcessor<TInput> rootProcessor)
    {
        if (_counter == 0 && rootProcessor.DependedProcessors.Count == 0 && !_completionWasFired)
        {
            _completionWasFired = true;
            await rootProcessor.SignalNestedProcessingCompletion();
        }
    }

    private async Task<(string, int)> AcquireAndLog(IFlatLadderProcessor<TInput> processor)
    {
        _counter++;
        await SemaphoreSlim.WaitAsync();

        var acquireId = new Random().Next(1, 10000);
        var dependentProcessorExists = processor.DependedProcessors.TryPeek(out var dependantProcessor);
        var rootCompleted = processor.IsStartedSelfProcessing && processor.IsCompletedCurrentProcessing;
        var dependantExistsAndRootCompleted = dependentProcessorExists && rootCompleted;

        var dependantProcessorTypeName =
            dependantExistsAndRootCompleted ? dependantProcessor.ProcessorTypeName : HimselfLabel;
        
        await loggingService.Log($"Id = {acquireId} AcquireTime{DateTime.Now}, Name = {processor.ProcessorName}, TypeName = {processor.ProcessorTypeName} for {dependantProcessorTypeName}",
            EventLoggingTypes.SemaphoreAcquired, processor.RootProcessorFromDependentQueue?.ProcessorTypeName);
        return (dependantProcessorTypeName, acquireId);
    }
    
    private async Task LogAndRelease(int acquireId, IFlatLadderProcessor<TInput> processor, string executionName, bool isExecutesAfterRelease = false)
    {
        var dependentProcessorExists = processor.DependedProcessors.TryPeek(out var dependantProcessor);
        var bufList =  processor.DependedProcessors.ToList();
        var dependantNames = GetElementNames(bufList);
        var executingAfterReleaseMessage = isExecutesAfterRelease ? $"Executing After Release With execution Dependencies: {dependantNames}" : "";
        var rootCompleted = processor.IsStartedSelfProcessing && processor.IsCompletedCurrentProcessing;
        var dependantExistsAndRootCompleted = dependentProcessorExists && rootCompleted;
        var dependantExistsAndRootCompletedAndDependantNotCompleted = dependantExistsAndRootCompleted 
                                                                      && !dependantProcessor.IsCompletedCurrentProcessing;
        
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
    
    private string GetElementNames(List<IFlatLadderProcessor<TInput>> list)
    {
        return string.Join(", ", list.Select(obj => obj.ProcessorTypeName));
    }

    private bool CheckIsNeedToKeepLockedUntilDependentRootReleased(IFlatLadderProcessor<TInput> processor)
    {
        if (processor== null)
        {
            return false;
        }

        var dependentProcessorExists = processor.DependedProcessors.TryPeek(out var dependantProcessor);
        
        var dependentsCount = processor.DependedProcessors.Count;

        var isNeedToKeepLockedUntilDependentRootReleased =
            processor.IsStartedSelfProcessing &&
            processor.IsCompletedCurrentProcessing &&
            dependentProcessorExists &&
            dependantProcessor.IsRoot &&
            !dependantProcessor.IsStartedSelfProcessing;
            // && dependentsCount == 1;
        
        return isNeedToKeepLockedUntilDependentRootReleased;
    }
    
    #endregion
}