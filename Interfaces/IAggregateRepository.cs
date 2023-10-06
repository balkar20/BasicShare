using Core.Base.EventSourcing;

namespace Infrastructure.Interfaces;

public interface IAggregateRepository<T> where T : AggregateRoot, new()
{
    Task Save(AggregateRoot aggregate, int expectedVersion);
    Task<T> GetById(Guid id);
}