using Data.Base.Objects;
using Mod.Order.EventData.Enums;
using Mod.Order.EventData.Events.Models;

// using Data.Ordering.Objects;
// using OrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;
// using PaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;

namespace Mod.Order.EventData.Events;

public class OrderCreatedEvent : EventObject
{
    public OrderCreatedEvent(string Description, OrderType OrderType, long paymentAccountId, PaymentInfo PaymentInfo, OrderNotification Notification, string customerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderType = OrderType;
        this.PaymentAccountId = paymentAccountId;
        this.PaymentInfo = PaymentInfo;
        this.Notification = Notification;
        this.CustomerId = customerId;
    }

    public OrderCreatedEvent(): base(Guid.NewGuid())
    {
        
    }

    public string Description { get; init; }
    public OrderType OrderType { get; init; }
    public long PaymentAccountId { get; init; }
    public PaymentInfo PaymentInfo { get; init; }
    public OrderNotification Notification { get; init; }
    public string CustomerId { get; init; }

    public void Deconstruct(out string Description, out OrderType OrderType, out long OrderProductId, out PaymentInfo PaymentInfo, out OrderNotification Notification, out string CustomerId)
    {
        Description = this.Description;
        OrderType = this.OrderType;
        OrderProductId = this.PaymentAccountId;
        PaymentInfo = this.PaymentInfo;
        Notification = this.Notification;
        CustomerId = this.CustomerId;
    }
} 