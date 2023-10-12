using Data.Base.Objects;
using CustomerInfo = Mod.Order.EventData.Events.Models.CustomerInfo;
using OrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;
using PaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;

namespace Mod.Order.EventData.Events;

public class OrderUpdatedEvent : EventObject
{
    public OrderUpdatedEvent(string Description, long OrderPayloadId, PaymentInfo PaymentInfo, OrderNotification Notification, string CustomerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderPayloadId = OrderPayloadId;
        this.PaymentInfo = PaymentInfo;
        this.Notification = Notification;
        this.CustomerId = CustomerId;
    }

    public string Description { get; init; }
    public long OrderPayloadId { get; init; }
    public PaymentInfo PaymentInfo { get; init; }
    public OrderNotification Notification { get; init; }
    public string CustomerId { get; init; }

    public void Deconstruct(out string Description, out long OrderPayloadId, out PaymentInfo PaymentInfo, out OrderNotification Notification, out string CustomerId)
    {
        Description = this.Description;
        OrderPayloadId = this.OrderPayloadId;
        PaymentInfo = this.PaymentInfo;
        Notification = this.Notification;
        CustomerId = this.CustomerId;
    }
} 