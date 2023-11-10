using Data.Base.Objects;
using Mod.Order.EventData.Events.Models;

namespace Mod.Order.EventData.Events;

public class OrderUpdatedPaymentInfoEvent : EventObject
{
    public OrderUpdatedPaymentInfoEvent(Guid id, OrderPaymentInfoEventModel orderPaymentInfoEventModel): base(id)
    {
        this.OrderPaymentInfoEventModel = orderPaymentInfoEventModel;
    }
    
    public OrderPaymentInfoEventModel OrderPaymentInfoEventModel { get; init; }

} 