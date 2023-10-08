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
            Guid.NewGuid(),
            model.Description,
            model.OrderType,
            model.OrderPayloadId,
            model.PaymentInfo,
            model.Notification,
            model.CustomerInfo
        );
        
        // ApplyChange(orderCreatedEvent);
    }
    
    public OrderAggregate(OrderModel state)
    {
        
    }
    
    public override Guid Id { get; }

    public string Order { get; set; }

    public OrderStatus OrderStatus { get; set; }
}