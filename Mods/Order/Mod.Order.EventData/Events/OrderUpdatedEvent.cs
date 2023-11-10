using Data.Base.Objects;
using Mod.Order.EventData.Events.Models;

namespace Mod.Order.EventData.Events;

public class OrderUpdatedEvent : EventObject
{
    public OrderUpdatedEvent(string Description, long OrderPayloadId, OrderPaymentInfoEventModel orderPaymentInfoEventModel, OrderNotificationEventModel notificationEventModel, string CustomerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderPayloadId = OrderPayloadId;
        this.OrderPaymentInfoEventModel = orderPaymentInfoEventModel;
        this.NotificationEventModel = notificationEventModel;
        this.CustomerId = CustomerId;
    }

    public string Description { get; init; }
    public long OrderPayloadId { get; init; }
    public OrderPaymentInfoEventModel OrderPaymentInfoEventModel { get; init; }
    public OrderNotificationEventModel NotificationEventModel { get; init; }
    public string CustomerId { get; init; }

    public void Deconstruct(out string Description, out long OrderPayloadId, out OrderPaymentInfoEventModel orderPaymentInfoEventModel, out OrderNotificationEventModel notificationEventModel, out string CustomerId)
    {
        Description = this.Description;
        OrderPayloadId = this.OrderPayloadId;
        orderPaymentInfoEventModel = this.OrderPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }
} 