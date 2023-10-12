using Data.Base.Objects;

namespace Mod.Order.EventData.Events;

public class OrderCompletedEvent : EventObject
{
    public OrderCompletedEvent(Guid id) : base(id)
    {
    }
}