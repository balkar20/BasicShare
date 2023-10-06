using Core.Base.EventSourcing;
using EventStore.Events;

namespace EventStore;

public interface IEventStore
{
    Task SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
    Task<List<Event>> GetEventsForAggregate(Guid aggregateId);
}