using AutoMapper;
using Core.Base.EventSourcing;
using Core.Base.Exceptions;
using Data.Base.Objects;
using Infrastructure.Interfaces;
using MongoDataServices;
using MongoObjects;

namespace Infrastructure.Services;

public class AggregateStorage : IAggregateStorage
{
    private readonly IMessageBusService _publisher;
    protected readonly IMapper _mapper;
    
    private IDataCollectionService<EventDocument> _eventStorage;
    
    private readonly Dictionary<Guid, List<EventDescriptor>> _current = new();
    
    public AggregateStorage(IMessageBusService publisher, IDataCollectionService<EventDocument> eventStorage, IMapper mapper)
    {
        _publisher = publisher;
        _eventStorage = eventStorage;
        _mapper = mapper;
    }

    public async Task<int> SaveEvents(Guid aggregateId, IEnumerable<EventObject> events, int expectedVersion)
    {
        var eventDescriptors = await _eventStorage.GetListByIdAsync(aggregateId);

        // check whether latest event version matches current aggregate version
        // otherwise -> throw exception
        if(eventDescriptors.Any() && eventDescriptors[^1].Version != expectedVersion && expectedVersion != -1)
        {
            throw new ConcurrencyException();
        }
        
        var i = expectedVersion;

        foreach (var @event in events)
        {
            i++;
            @event.Version = i;

            var eventDocument = _mapper.Map<EventDocument>(@event);

            await _eventStorage.CreateAsync(eventDocument);

            await _publisher.PublishMessage(@event);
        }
        return i;
    }

    public async Task<List<EventDocument>> GetEventsForAggregate(Guid aggregateId)
    {
        return await _eventStorage.GetListByIdAsync(aggregateId);
    }
}