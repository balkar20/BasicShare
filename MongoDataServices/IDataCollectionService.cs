using Core.Base.DataBase.Interfaces;
using MongoObjects;

namespace MongoDataServices;

public interface IDataCollectionService<TData> where TData : EventDocument
{
    Task<List<TData>> GetAsync();
    Task<List<TData>> GetListByIdAsync(string id);
    Task<TData?> GetAsync(string id);
    Task CreateAsync(TData newTData);
    Task UpdateAsync(string id, TData updatedData);
    Task RemoveAsync(string id);
    
    
}