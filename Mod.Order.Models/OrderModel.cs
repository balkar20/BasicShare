using Mod.Order.Models.Enums;

namespace Mod.Order.Models;

public class OrderModel
{
    public long Id { get; set; }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }
    
    public OrderStatus OrderStatus { get; set; }

    public long OrderPayloadId { get; set; }
    
    public PaymentInfo PaymentInfo { get; set; }
           
    public OrderNotification Notification { get; set; }
           
    public CustomerInfo CustomerInfo { get; set; }
}