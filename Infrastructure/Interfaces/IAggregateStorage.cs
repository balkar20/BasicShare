using Data.Base.Objects;
using MongoObjects;

namespace Infrastructure.Interfaces;

public interface IAggregateStorage
{
    Task<int>  SaveEvents(Guid aggregateId, IEnumerable<EventObject> events, int expectedVersion);
    Task<List<EventDocument>> GetEventsForAggregate(Guid aggregateId);
}