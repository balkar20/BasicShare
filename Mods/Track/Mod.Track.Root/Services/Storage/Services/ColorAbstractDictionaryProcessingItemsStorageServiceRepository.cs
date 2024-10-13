using ParallelProcessing.Exceptions;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Services.Storage.Abstractions;

namespace ParallelProcessing.Services.Storage.Services;

public  class ColorAbstractDictionaryProcessingItemsStorageServiceRepository: IProcessingItemsStorageServiceRepository<string, Track, VehicleColorProcessionResult>
{
    private ISharedMemoryStorage sharedMemoryStorage;

    public ColorAbstractDictionaryProcessingItemsStorageServiceRepository(ISharedMemoryStorage sharedMemoryStorage)
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


    public async Task CreateProcessingItemResult(VehicleColorProcessionResult result)
    {
        if (!sharedMemoryStorage.ProcessionColorResultStorage.TryAdd(Guid.NewGuid().ToString(), result))
        {
            throw new ProcessingItemResultCreationException(result);
        }
    }
    
        public Task CreateProcessingItemResult(IProcessionResult processionResult)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<Track> GetProcessingItem(string processItemKey)
    {
        sharedMemoryStorage.ProcessingItemsStorage.TryGetValue(processItemKey, out var result);
        return result;
    }

    public virtual async Task<IProcessionResult> GetProcessingItemResult(string processItemKey)
    {
        sharedMemoryStorage.ProcessionColorResultStorage.TryGetValue(processItemKey, out var result);
        return result;
    }
    
}