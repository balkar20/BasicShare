using Core.Base.EventSourcing;
using Mod.Order.Models;

namespace Mod.Order.EventData.Events;

public record OrderUpdated(string Description, OrderType OrderType, long OrderPayloadId, PaymentInfo PaymentInfo, OrderNotification Notification, CustomerInfo CustomerInfo) : Event; 