using Core.Base.EventSourcing;
using Data.Ordering.Objects;
using CustomerInfo = Mod.Order.EventData.Events.Models.CustomerInfo;
using OrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;
using PaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;

namespace Mod.Order.EventData.Events;

public class OrderUpdatedEvent : EventObject
{
    public OrderUpdatedEvent(string Description, long OrderPayloadId, PaymentInfo PaymentInfo, OrderNotification Notification, CustomerInfo CustomerInfo): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderPayloadId = OrderPayloadId;
        this.PaymentInfo = PaymentInfo;
        this.Notification = Notification;
        this.CustomerInfo = CustomerInfo;
    }

    public string Description { get; init; }
    public long OrderPayloadId { get; init; }
    public PaymentInfo PaymentInfo { get; init; }
    public OrderNotification Notification { get; init; }
    public CustomerInfo CustomerInfo { get; init; }

    public void Deconstruct(out string Description, out long OrderPayloadId, out PaymentInfo PaymentInfo, out OrderNotification Notification, out CustomerInfo CustomerInfo)
    {
        Description = this.Description;
        OrderPayloadId = this.OrderPayloadId;
        PaymentInfo = this.PaymentInfo;
        Notification = this.Notification;
        CustomerInfo = this.CustomerInfo;
    }
} 