namespace EventBus.Events.Interfaces;

public interface IOrderCompletedEvent
{
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
}