
using Data.Base.Objects;

namespace MongoDataServices;

public interface IDataCollectionService<TData> where TData : EventDocument
{
    Task<List<TData>> GetAsync();
    Task<List<TData>> GetListByIdAsync(Guid id);
    Task<TData?> GetAsync(Guid id);
    Task CreateAsync(TData newTData);
    Task UpdateAsync(Guid id, TData updatedData);
    Task RemoveAsync(Guid id);
    
    
}