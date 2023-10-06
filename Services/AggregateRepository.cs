using Core.Base.EventSourcing;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class AggregateRepository<T>: IAggregateRepository<T> where T: AggregateRoot, new() 
{
    private readonly IAggregateStorage _storage;

    public AggregateRepository(IAggregateStorage storage)
    {
        _storage = storage;
    }

    public async Task Save(AggregateRoot aggregate, int expectedVersion)
    {
        await _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
    }

    public async Task<T> GetById(Guid id)
    {
        var obj = new T();//lots of ways to do this
        var e = await _storage.GetEventsForAggregate(id);
        obj.LoadsFromHistory(e);
        return obj;
    }
}