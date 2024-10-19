using System.Collections.Generic;
using EventBus.Events;

namespace EventBus.Messages.Interfaces;

public interface ICreateOrderMessage: IBaseSagaMessage
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid PaymentAccountId { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItemList { get; set; }
}