using AutoMapper;
using Core.Base.EventSourcing;
using Data.Ordering.Objects;
using Infrastructure.Interfaces;
using MassTransit.Initializers;
using MongoObjects;

namespace Infrastructure.Services;

public class AggregateRepository<T>: IAggregateRepository<T> where T: AggregateRoot, new() 
{
    private readonly IAggregateStorage _storage;
    protected readonly IMapper _mapper;

    public AggregateRepository(IAggregateStorage storage, IMapper mapper)
    {
        _storage = storage;
        _mapper = mapper;
    }

    public async Task Save(AggregateRoot aggregate, int expectedVersion)
    {
        var changes = aggregate
            .GetUncommittedChanges();
        await _storage.SaveEvents(aggregate.Id, changes, expectedVersion);
    }

    public async Task<T> GetById(Guid id)
    {
        var obj = new T();//lots of ways to do this
        var e = (await _storage
            .GetEventsForAggregate(id))
            .Select(m => _mapper.Map<EventObject>(m));
        obj.LoadsFromHistory(e);
        return obj;
    }
}