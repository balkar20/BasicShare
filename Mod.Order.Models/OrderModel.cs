namespace Mod.Order.Models;

public class OrderModel
{
    public long Id { get; set; }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }

    public long OrderPayloadId { get; set; }
    
    public PaymentInfo PaymentInfo { get; set; }
           
    public OrderNotification Notification { get; set; }
           
    public CustomerInfo CustomerInfo { get; set; }
}

public class CustomerInfo
{
    public string UserId { get; set; }
}

public class PaymentInfo
{
    public decimal Price { get; set; }
}

public class OrderNotification
{
    public NotificationType NotificationType { get; set; }
}

public enum NotificationType
{
    Email,
    Phone,
    Telegram,
    InApplication,
}

public enum OrderType
{
    Work,
    Product,
    Shipment
}