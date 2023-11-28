using EventBus.Events.Interfaces;

namespace EventBus.Events;

public class PaymentFailedEvent : IPaymentFailedEvent
{
    public Guid CorrelationId { get; set; }
    public List<OrderItem> OrderItemList { get; set; }
    public string ErrorMessage { get; set; }
}