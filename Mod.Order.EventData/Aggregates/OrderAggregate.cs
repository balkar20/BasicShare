using Core.Base.EventSourcing;
using Mod.Order.EventData.Events;
using Mod.Order.Models;
using Mod.Order.Models.Enums;

namespace Mod.Order.EventData.Aggregates;

public class OrderAggregate: AggregateRoot
{
    public OrderAggregate()
    {
        
    }
    
    public OrderAggregate(Guid id, OrderModel model)
    {
        var orderCreatedEvent = new OrderCreatedEvent(
            model.Description,
            model.OrderType,
            model.OrderPayloadId,
            model.PaymentInfo,
            model.Notification,
            model.CustomerInfo
        );
        
        ApplyChange(orderCreatedEvent);
    }
    
    private void Apply(OrderCreatedEvent e)
    {
        this.Description = e.Description;
        this.OrderType = e.OrderType;
        this.PaymentInfo = e.PaymentInfo;
        this.Notification = e.Notification;
        this.CustomerInfo = e.CustomerInfo;
        this.OrderStatus = OrderStatus.Created;
    }
    
    private void Apply(OrderUpdatedEvent e)
    {
        this.Description = e.Description;
        this.PaymentInfo = e.PaymentInfo;
        this.Notification = e.Notification;
        this.CustomerInfo = e.CustomerInfo;
        this.OrderStatus = OrderStatus.Updated;
    }
    
    private void Apply(OrderCanceledEvent e)
    {
        this.OrderStatus = OrderStatus.Canceled;
    }
    
    private void Apply(OrderCompletedEvent e)
    {
        this.OrderStatus = OrderStatus.Completed;
    }
    
    public OrderAggregate(OrderModel state)
    {
        
    }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }

    public long OrderPayloadId { get; set; }
    
    public PaymentInfo PaymentInfo { get; set; }
           
    public OrderNotification Notification { get; set; }
           
    public CustomerInfo CustomerInfo { get; set; }
    
    public override Guid Id { get; }

    public string Order { get; set; }

    public OrderStatus OrderStatus { get; set; }
}