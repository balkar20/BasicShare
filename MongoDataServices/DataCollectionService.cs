using Core.Base.ConfigurationInterfaces;
using Core.Base.DataBase.Interfaces;
using MongoDB.Driver;
using MongoObjects;

namespace MongoDataServices;

public class DataCollectionService<TData>: IDataCollectionService<TData> where TData : EventDocument
{
    private readonly IMongoCollection<TData> _dataCollection;

    public DataCollectionService(
        IDocumentDataConfiguration DataStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            DataStoreDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            DataStoreDatabaseSettings.DatabaseName);

        _dataCollection = mongoDatabase.GetCollection<TData>(
            DataStoreDatabaseSettings.DataCollectionName);
    }

    public async Task<List<TData>> GetAsync() =>
        await _dataCollection.Find(_ => true).ToListAsync();

    public async Task<List<TData>> GetListByIdAsync(string id) =>
        await _dataCollection.Find(x => x.Id == id).ToListAsync();
    
    public async Task<TData?> GetAsync(string id) =>
        await _dataCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TData newTData) =>
        await _dataCollection.InsertOneAsync(newTData);

    public async Task UpdateAsync(string id, TData updatedData) =>
        await _dataCollection.ReplaceOneAsync(x => x.Id == id, updatedData);

    public async Task RemoveAsync(string id) =>
        await _dataCollection.DeleteOneAsync(x => x.Id == id);
}