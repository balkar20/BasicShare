using Core.Base.EventSourcing;
using Data.Ordering.Objects;
using MongoObjects;
using CustomerInfo = Mod.Order.Models.CustomerInfo;
using OrderNotification = Mod.Order.Models.OrderNotification;
using OrderType = Mod.Order.Models.OrderType;
using PaymentInfo = Mod.Order.Models.PaymentInfo;

namespace Mod.Order.EventData.Events;

public class OrderCreatedEvent : EventObject
{
    public OrderCreatedEvent(string Description, OrderType OrderType, long OrderProductId, PaymentInfo PaymentInfo, OrderNotification Notification, CustomerInfo CustomerInfo): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.OrderType = OrderType;
        this.OrderProductId = OrderProductId;
        this.PaymentInfo = PaymentInfo;
        this.Notification = Notification;
        this.CustomerInfo = CustomerInfo;
    }

    public string Description { get; init; }
    public OrderType OrderType { get; init; }
    public long OrderProductId { get; init; }
    public PaymentInfo PaymentInfo { get; init; }
    public OrderNotification Notification { get; init; }
    public CustomerInfo CustomerInfo { get; init; }

    public void Deconstruct(out string Description, out OrderType OrderType, out long OrderProductId, out PaymentInfo PaymentInfo, out OrderNotification Notification, out CustomerInfo CustomerInfo)
    {
        Description = this.Description;
        OrderType = this.OrderType;
        OrderProductId = this.OrderProductId;
        PaymentInfo = this.PaymentInfo;
        Notification = this.Notification;
        CustomerInfo = this.CustomerInfo;
    }
} 