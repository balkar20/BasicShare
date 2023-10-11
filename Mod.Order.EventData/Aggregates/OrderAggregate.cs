using Core.Base.EventSourcing;
using Mod.Order.EventData.Enums;
using Mod.Order.EventData.Events;
using Mod.Order.EventData.Events.Models;
// using Mod.Order.EventData.Events.Models;
using OrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;

namespace Mod.Order.EventData.Aggregates;

public class OrderAggregate: AggregateRoot
{
    
    private Guid _id;

    public OrderAggregate()
    {
        
    }
    
    public override Guid Id
    {
        get { return _id; }
    }
    
    public OrderAggregate(Guid id, OrderCreationData model)
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
        _id = Guid.NewGuid();
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
    
    public OrderAggregate(OrderCreationData state)
    {
        ApplyChange(new OrderCreatedEvent(state.Description, state.OrderType, state.OrderPayloadId, state.PaymentInfo, state.Notification, state.CustomerInfo));
    }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }

    public long OrderPayloadId { get; set; }
    
    public PaymentInfo PaymentInfo { get; set; }
           
    public OrderNotification Notification { get; set; }
           
    public CustomerInfo CustomerInfo { get; set; }

    public string Order { get; set; }

    public OrderStatus OrderStatus { get; set; }
}