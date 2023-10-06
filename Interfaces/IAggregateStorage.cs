using Core.Base.EventSourcing;

namespace Infrastructure.Interfaces;

public interface IAggregateStorage
{
    Task SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
    Task<List<Event>> GetEventsForAggregate(Guid aggregateId);
}