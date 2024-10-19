using Data.Base.Objects;
using Mod.Order.EventData.Events.Models;

namespace Mod.Order.EventData.Events;

public class OrderUpdatedEvent : EventObject
{
    public OrderUpdatedEvent(string Description, Guid OrderPayloadId, OrderPaymentInfoEventModel orderPaymentInfoEventModel, OrderNotificationEventModel notificationEventModel, Guid CustomerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderPayloadId = OrderPayloadId;
        this.OrderPaymentInfoEventModel = orderPaymentInfoEventModel;
        this.NotificationEventModel = notificationEventModel;
        this.CustomerId = CustomerId;
    }

    public string Description { get; init; }
    public Guid OrderPayloadId { get; init; }
    public OrderPaymentInfoEventModel OrderPaymentInfoEventModel { get; init; }
    public OrderNotificationEventModel NotificationEventModel { get; init; }
    public Guid CustomerId { get; init; }

    public void Deconstruct(out string Description, out Guid OrderPayloadId, out OrderPaymentInfoEventModel orderPaymentInfoEventModel, out OrderNotificationEventModel notificationEventModel, out Guid CustomerId)
    {
        Description = this.Description;
        OrderPayloadId = this.OrderPayloadId;
        orderPaymentInfoEventModel = this.OrderPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }
} 