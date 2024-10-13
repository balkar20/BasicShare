using System.Collections.Concurrent;
using ParallelProcessing.Exceptions;
using ParallelProcessing.Models.Items.Analysing;

namespace ParallelProcessing.Services;

public interface IAnalysingItemsStorageRepository<TItem, TKey>
{
    Task CreateAnalysingItem(TItem analisyngItem);
    Task<TItem> GetProcessingItem(TKey processItemKey);
}

class AbstractDictionaryAnalysingItemsStorageRepository : IAnalysingItemsStorageRepository<AnalysingItem, string>
{
    private ConcurrentDictionary<string, AnalysingItem> ProcessingItemsStorage => new ();
    public async Task CreateAnalysingItem(AnalysingItem analisyngItem)
    {
        if (!ProcessingItemsStorage.TryAdd(Guid.NewGuid().ToString(), analisyngItem))
        {
            throw new AnalysingItemCreationException(analisyngItem);
        }
    }

    /// <summary>
    /// Here we can set-up unit-Test mocks
    /// </summary>
    /// <param name="processItemKey"></param>
    /// <returns></returns>
    public async Task<AnalysingItem> GetProcessingItem(string processItemKey)
    {
         ProcessingItemsStorage.TryGetValue(processItemKey, out var item);
         return item;
    }
}