namespace EventBus.Events.Interfaces;

public interface IOrderFailedEvent
{
    public Guid OrderId { get; set; }
    public string CustomerId { get; set; }
    public string ErrorMessage { get; set; }
}