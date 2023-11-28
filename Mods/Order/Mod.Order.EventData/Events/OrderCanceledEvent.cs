using Data.Base.Objects;

namespace Mod.Order.EventData.Events;

public class OrderCanceledEvent:EventObject
{
    public OrderCanceledEvent(Guid id) : base(id)
    {
    }
}