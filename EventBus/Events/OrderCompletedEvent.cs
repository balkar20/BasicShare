using EventBus.Events.Interfaces;

namespace EventBus.Events;

public class OrderCompletedEvent : IOrderCompletedEvent
{
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
}