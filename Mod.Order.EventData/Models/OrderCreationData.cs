using Mod.Order.EventData.Enums;

namespace Mod.Order.EventData.Events.Models;

public record OrderCreationData(string Description, OrderType OrderType, long OrderPayloadId, PaymentInfo PaymentInfo, OrderNotification Notification, string CustomerId);
