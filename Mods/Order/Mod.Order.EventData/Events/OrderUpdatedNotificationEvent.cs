using Data.Base.Objects;
using Mod.Order.EventData.Events.Models;

namespace Mod.Order.EventData.Events;

public class OrderUpdatedNotificationEvent : EventObject
{
    public OrderUpdatedNotificationEvent(Guid id, OrderNotificationEventModel notificationEventModel): base(id)
    {
        this.NotificationEventModel = notificationEventModel;
    }
    
    public OrderNotificationEventModel NotificationEventModel { get; init; }

} 