using Core.Base.DataBase.Interfaces;

namespace MongoDataServices;

public interface IDataCollectionService<TData> where TData : IDocument
{
    Task<List<TData>> GetAsync();
    Task<TData?> GetAsync(string id);
    Task CreateAsync(TData newTData);
    Task UpdateAsync(string id, TData updatedData);
    Task RemoveAsync(string id);
}