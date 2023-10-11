using Mod.Order.EventData.Enums;

namespace Mod.Order.EventData.Events.Models;

public class OrderNotification
{
    public NotificationType NotificationType { get; set; }
}