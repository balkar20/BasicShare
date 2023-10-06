using Core.Base.EventSourcing;
using Core.Base.Exceptions;
using Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Services;

public class AggregateStorage : IAggregateStorage
{
    private readonly IMessageBusService _publisher;
    private readonly MongoClient  _eventStorage;
    
    private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();
    
    public AggregateStorage(IMessageBusService publisher)
    {
        _publisher = publisher;
    }

    public async Task SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
    {
        List<EventDescriptor> eventDescriptors;

        // try to get event descriptors list for given aggregate id
        // otherwise -> create empty dictionary
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
            eventDescriptors.Add(new EventDescriptor(aggregateId,@event,i));

            // publish current event to the bus for further processing by subscribers
            _publisher.PublishMessage(@event);
        }
    }

    public Task<List<Event>> GetEventsForAggregate(Guid aggregateId)
    {
        throw new NotImplementedException();
    }
}