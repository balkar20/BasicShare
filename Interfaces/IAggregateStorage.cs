using Data.Ordering.Objects;
using MongoObjects;

namespace Infrastructure.Interfaces;

public interface IAggregateStorage
{
    Task SaveEvents(Guid aggregateId, IEnumerable<EventObject> events, int expectedVersion);
    Task<List<EventDocument>> GetEventsForAggregate(Guid aggregateId);
}