using Mod.Order.EventData.Enums;

namespace Mod.Order.EventData.Events.Models;

public class OrderNotificationEventModel
{
    public NotificationType NotificationType { get; set; }
}