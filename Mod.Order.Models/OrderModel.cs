using Mod.Order.Models.Enums;

namespace Mod.Order.Models;

public class OrderModel
{
    public Guid Id { get; set; }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }
    
    public OrderStatus OrderStatus { get; set; }

    public long OrderPayloadId { get; set; }
    
    public OrderPaymentInfoModel OrderPaymentInfoModel { get; set; }
           
    public OrderNotificationModel NotificationModel { get; set; }
           
    public string CustomerId { get; set; }
    
    public List<OrderItemModel> OrderItemList { get; set; }
}