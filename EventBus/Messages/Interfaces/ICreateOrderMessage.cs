using System.Collections.Generic;
using EventBus.Events;

namespace EventBus.Messages.Interfaces;

public interface ICreateOrderMessage: IBaseSagaMessage
{
    public Guid OrderId { get; set; }
    public string CustomerId { get; set; }
    public string PaymentAccountId { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItemList { get; set; }
}