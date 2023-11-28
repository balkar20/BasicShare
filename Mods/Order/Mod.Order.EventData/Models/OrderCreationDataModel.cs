using MassTransit;
using Mod.Order.EventData.Enums;

namespace Mod.Order.EventData.Events.Models;

public class OrderCreationDataModel
{
    // public OrderCreationDataModel(string Description, OrderType OrderType, long OrderPayloadId, OrderPaymentInfoEventModel OrderPaymentInfoEventModel,
    //     OrderNotificationEventModel NotificationEventModel, string CustomerId)
    // {
    //     this.Description = Description;
    //     this.OrderType = OrderType;
    //     this.OrderPayloadId = OrderPayloadId;
    //     this.OrderPaymentInfoEventModel = OrderPaymentInfoEventModel;
    //     this.NotificationEventModel = NotificationEventModel;
    //     this.CustomerId = CustomerId;
    // }

    public string Description { get; set; }
    public OrderType OrderType { get; set; }
    public long OrderPayloadId { get; set; }
    public OrderPaymentInfoEventModel OrderPaymentInfoEventModel { get; set; }
    public OrderNotificationEventModel NotificationEventModel { get; set; }
    public string CustomerId { get; set; }

    public void Deconstruct(out string Description, out OrderType OrderType, out long OrderPayloadId, out OrderPaymentInfoEventModel orderPaymentInfoEventModel, out OrderNotificationEventModel notificationEventModel, out string CustomerId)
    {
        Description = this.Description;
        OrderType = this.OrderType;
        OrderPayloadId = this.OrderPayloadId;
        orderPaymentInfoEventModel = this.OrderPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }
}
