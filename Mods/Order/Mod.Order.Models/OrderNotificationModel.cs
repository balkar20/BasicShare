using Mod.Order.Models.Enums;

namespace Mod.Order.Models;

public class OrderNotificationModel: OrderIdModel
{
    public NotificationType NotificationType { get; set; }
}