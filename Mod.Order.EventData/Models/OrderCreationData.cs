using MassTransit;
using Mod.Order.EventData.Enums;

namespace Mod.Order.EventData.Events.Models;

public record OrderCreationData
{
    public OrderCreationData(string Description, OrderType OrderType, long OrderPayloadId, PaymentInfo PaymentInfo,
        OrderNotification Notification, string CustomerId)
    {
        this.Description = Description;
        this.OrderType = OrderType;
        this.OrderPayloadId = OrderPayloadId;
        this.PaymentInfo = PaymentInfo;
        this.Notification = Notification;
        this.CustomerId = CustomerId;
    }

    public OrderCreationData()
    {
        
    }

    public string Description { get; init; }
    public OrderType OrderType { get; init; }
    public long OrderPayloadId { get; init; }
    public PaymentInfo PaymentInfo { get; init; }
    public OrderNotification Notification { get; init; }
    public string CustomerId { get; init; }

    public void Deconstruct(out string Description, out OrderType OrderType, out long OrderPayloadId, out PaymentInfo PaymentInfo, out OrderNotification Notification, out string CustomerId)
    {
        Description = this.Description;
        OrderType = this.OrderType;
        OrderPayloadId = this.OrderPayloadId;
        PaymentInfo = this.PaymentInfo;
        Notification = this.Notification;
        CustomerId = this.CustomerId;
    }
}
