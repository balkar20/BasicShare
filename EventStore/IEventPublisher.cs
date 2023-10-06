using Core.Base.EventSourcing;
using EventStore.Events;

namespace EventStore;

public interface IEventPublisher
{
    Task Publish<T>(T @event) where T : Event;
}