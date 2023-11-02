using AutoMapper;
using Core.Base.EventSourcing;
using Data.Base.Objects;
using Infrastructure.Interfaces;

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

    public async Task<int> Save(AggregateRoot aggregate, int expectedVersion)
    {
        var changes = aggregate
            .GetUncommittedChanges();
        aggregate.Version =  await _storage.SaveEvents(aggregate.Id, changes, expectedVersion);
        return aggregate.Version;
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