using ParallelProcessing.Models.Results.Procession.Abstractions;

namespace ParallelProcessing.Services;

public interface IProcessingItemsStorageServiceRepository<TProcessingItemKey, TProcessingItem, TProcessingItemResult>
{
    Task CreateProcessingItem(TProcessingItem processItem);
    Task<TProcessingItem> GetProcessingItem(TProcessingItemKey processItemKey);
    Task<IProcessionResult> GetProcessingItemResult(TProcessingItemKey processItemKey);
    Task CreateProcessingItemResult(TProcessingItemResult processionResult);

}