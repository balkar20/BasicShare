using EventBus.Events.Interfaces;

namespace EventBus.Events;

public class OrderFailedEvent : IOrderFailedEvent
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public string ErrorMessage { get; set; }
}