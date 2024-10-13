using ParallelProcessing.Exceptions;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Services.Storage.Abstractions;

namespace ParallelProcessing.Services.Storage.Services;

public  class MarkAbstractDictionaryProcessingItemsStorageServiceRepository: IProcessingItemsStorageServiceRepository<string, Track, VehicleMarkProcessionResult>
{
    private ISharedMemoryStorage sharedMemoryStorage;

    public MarkAbstractDictionaryProcessingItemsStorageServiceRepository(ISharedMemoryStorage sharedMemoryStorage)
    {
        this.sharedMemoryStorage = sharedMemoryStorage;
    }

    public async Task CreateProcessingItem(Track processItem)
    {
        if (!sharedMemoryStorage.ProcessingItemsStorage.TryAdd(Guid.NewGuid().ToString(), processItem))
        {
            throw new ProcessingItemCreationException(processItem);
        }
    }


    public async Task CreateProcessingItemResult(VehicleMarkProcessionResult result)
    {
        if (!sharedMemoryStorage.ProcessionMarkResultStorage.TryAdd(Guid.NewGuid().ToString(), result))
        {
            throw new ProcessingItemResultCreationException(result);
        }
    }

    public virtual async Task<Track> GetProcessingItem(string processItemKey)
    {
        sharedMemoryStorage.ProcessingItemsStorage.TryGetValue(processItemKey, out var result);
        return result;
    }

    public virtual async Task<IProcessionResult> GetProcessingItemResult(string processItemKey)
    {
        sharedMemoryStorage.ProcessionMarkResultStorage.TryGetValue(processItemKey, out var result);
        return result;
    }
}