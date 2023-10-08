using Core.Base.DataBase.Interfaces;
using Core.Base.EventSourcing;
using MongoObjects;

namespace Infrastructure.Interfaces;

public interface IAggregateStorage
{
    Task SaveEvents(Guid aggregateId, IEnumerable<EventDocument> events, int expectedVersion);
    Task<List<EventDocument>> GetEventsForAggregate(Guid aggregateId);
}