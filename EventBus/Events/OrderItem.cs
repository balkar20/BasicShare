namespace EventBus.Events;

public class OrderItem
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}