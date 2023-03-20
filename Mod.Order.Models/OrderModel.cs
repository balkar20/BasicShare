namespace Mod.Order.Models;

public class OrderModel
{
    public long Id { get; set; }
    
    public string Description { get; set; }
    
    public OrderType OrderType { get; set; }

    public long OrderPayloadId { get; set; }
    
    public IPaymentInfo PaymentInfo { get; set; }
           
    public IOrderNotification Notification { get; set; }
           
    public ICustomerInfo CustomerInfo { get; set; }
}

public interface ICustomerInfo
{
    public string UserId { get; set; }
}

public interface IPaymentInfo
{
    public decimal Price { get; set; }
}

public interface IOrderNotification
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