using Core.Base.DataBase.Interfaces;
using Core.Base.EventSourcing;
using Core.Base.Exceptions;
using Infrastructure.Interfaces;
using MongoDataServices;
using MongoDB.Driver;
using MongoObjects;

namespace Infrastructure.Services;

public class AggregateStorage : IAggregateStorage
{
    private readonly IMessageBusService _publisher;
    // private readonly MongoClient  _eventStorage;
    private IDataCollectionService<EventDocument> _eventStorage;
    
    private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();
    
    public AggregateStorage(IMessageBusService publisher, IDataCollectionService<EventDocument> eventStorage)
    {
        _publisher = publisher;
        _eventStorage = eventStorage;
    }

    public async Task SaveEvents(Guid aggregateId, IEnumerable<EventDocument> events, int expectedVersion)
    {
        List<EventDescriptor> eventDescriptors;

        // try to get event descriptors list for given aggregate id
        // otherwise -> create empty dictionary
        var eventsForAggregate  = await _eventStorage.GetAsync(aggregateId.ToString());
        if(!_current.TryGetValue(aggregateId, out eventDescriptors))
        {
            eventDescriptors = new List<EventDescriptor>();
            _current.Add(aggregateId,eventDescriptors);
        }
        // check whether latest event version matches current aggregate version
        // otherwise -> throw exception
        else if(eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion && expectedVersion != -1)
        {
            throw new ConcurrencyException();
        }
        var i = expectedVersion;

        // iterate through current aggregate events increasing version with each processed event
        foreach (var @event in events)
        {
            i++;
            @event.Version = i;

            // push event to the event descriptors list for current aggregate
            await _eventStorage.CreateAsync(@event);
            // eventDescriptors.Add(new EventDescriptor(aggregateId,@event,i));

            // publish current event to the bus for further processing by subscribers
            _publisher.PublishMessage(@event);
        }
    }

    public async Task<List<EventDocument>> GetEventsForAggregate(Guid aggregateId)
    {
        return await _eventStorage.GetListByIdAsync(aggregateId.ToString());
    }
}