namespace EventBus.Events.Interfaces;

public interface IOrderCompletedEvent
{
    public string CustomerId { get; set; }
    public Guid OrderId { get; set; }
}