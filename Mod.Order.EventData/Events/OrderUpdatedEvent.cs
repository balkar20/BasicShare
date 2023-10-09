using Core.Base.EventSourcing;
using Mod.Order.Models;

namespace Mod.Order.EventData.Events;

public record OrderUpdatedEvent(string Description, long OrderPayloadId, PaymentInfo PaymentInfo, OrderNotification Notification, CustomerInfo CustomerInfo) : Event; 