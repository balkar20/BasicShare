using System.Collections.Generic;
using EventBus.Events;
using EventBus.Messages.Interfaces;

namespace EventBus.Messages;

public class CreateOrderMessage : ICreateOrderMessage
{
    public CreateOrderMessage()
    {
        OrderItemList = new List<OrderItem>();
    }

    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid PaymentAccountId { get; set; }
    public decimal TotalPrice { get; set; }

    public List<OrderItem> OrderItemList { get; set; }
}