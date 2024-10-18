using Core.Base.EventSourcing;
using Mod.Order.EventData.Enums;
using Mod.Order.EventData.Events;
using Mod.Order.EventData.Events.Models;
// using Mod.Order.EventData.Events.Models;

namespace Mod.Order.EventData.Aggregates;

public class OrderAggregate: AggregateRoot
{
    
    private Guid _id;
    
    public override Guid Id
    {
        get { return _id; }
    }

    public OrderAggregate()
    {
        
    }
    public OrderAggregate(Guid id, OrderCreationDataModel model)
    {
        var orderCreatedEvent = new OrderCreatedEvent(
            model.Description,
            model.OrderType,
            model.OrderPayloadId,
            model.OrderPaymentInfoEventModel,
            model.NotificationEventModel,
            model.CustomerId
        );
        
        ApplyChange(orderCreatedEvent);
    }
    
    private void Apply(OrderCreatedEvent e)
    {
        _id = Guid.NewGuid();
        this.Description = e.Description;
        this.OrderType = e.OrderType;
        this.OrderPaymentInfoEventModel = e.OrderPaymentInfoEventModel;
        this.NotificationEventModel = e.NotificationEventModel;
        this.CustomerId = e.CustomerId;
        this.OrderStatus = OrderStatus.Created;
    }
    
    private void Apply(OrderUpdatedEvent e)
    {
        this.Description = e.Description;
        this.OrderPaymentInfoEventModel = e.OrderPaymentInfoEventModel;
        this.NotificationEventModel = e.NotificationEventModel;
        this.CustomerId = e.CustomerId;
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
    
    private void Apply(OrderUpdatedNotificationEvent e)
    {
        this.NotificationEventModel = e.NotificationEventModel;
    }
    
    private void Apply(OrderUpdatedPaymentInfoEvent e)
    {
        this.OrderPaymentInfoEventModel = e.OrderPaymentInfoEventModel;
    }
    
    public OrderAggregate(OrderCreationDataModel state)
    {
        _id = Guid.NewGuid();
        ApplyChange(new OrderCreatedEvent(state.Description, state.OrderType, state.OrderPayloadId, state.OrderPaymentInfoEventModel, state.NotificationEventModel, state.CustomerId));
    }
    
    public void UpdateNotification(OrderNotificationEventModel state)
    {
        ApplyChange(new OrderUpdatedNotificationEvent(this.Id, state));
    }
    
    public void UpdatePaymentInfo(OrderPaymentInfoEventModel state)
    {
        ApplyChange(new OrderUpdatedPaymentInfoEvent(this.Id, state));
    }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }

    public long OrderPayloadId { get; set; }
    
    public OrderPaymentInfoEventModel OrderPaymentInfoEventModel { get; set; }
           
    public OrderNotificationEventModel NotificationEventModel { get; set; }
           
    public string CustomerId { get; set; }

    public string Order { get; set; }

    public OrderStatus OrderStatus { get; set; }
}