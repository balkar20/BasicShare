using Data.Base.Objects;
using Mod.Order.EventData.Enums;
using Mod.Order.EventData.Events.Models;

// using Data.Ordering.Objects;
// using OrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;
// using PaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;

namespace Mod.Order.EventData.Events;

public class OrderCreatedEvent : EventObject
{
    public OrderCreatedEvent(string Description, OrderType OrderType, Guid paymentAccountId, OrderPaymentInfoEventModel orderPaymentInfoEventModel, OrderNotificationEventModel notificationEventModel, Guid customerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderType = OrderType;
        this.PaymentAccountId = paymentAccountId;
        this.OrderPaymentInfoEventModel = orderPaymentInfoEventModel;
        this.NotificationEventModel = notificationEventModel;
        this.CustomerId = customerId;
    }

    public OrderCreatedEvent(): base(Guid.NewGuid())
    {
        
    }

    public Guid OrderProductId { get; set; }
    public string Description { get; init; }
    public OrderType OrderType { get; init; }
    public Guid PaymentAccountId { get; init; }
    public OrderPaymentInfoEventModel OrderPaymentInfoEventModel { get; init; }
    public OrderNotificationEventModel NotificationEventModel { get; init; }
    public Guid CustomerId { get; init; }

    public void Deconstruct(out string Description, out OrderType OrderType, out Guid OrderProductId, out OrderPaymentInfoEventModel orderPaymentInfoEventModel, out OrderNotificationEventModel notificationEventModel, out Guid CustomerId, out Guid PaymentAccountId)
    {
        Description = this.Description;
        OrderType = this.OrderType;
        OrderProductId = this.OrderProductId;
        PaymentAccountId = this.PaymentAccountId;
        orderPaymentInfoEventModel = this.OrderPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }

} 