using Core.Base.DataBase.Interfaces;
using Core.Base.Models.Enums;

namespace Core.Base.DataBase.Entities;

public class TrackEntity: IEntity
{
    public Guid Id { get; set; }
    
    public string Description { get; set; }
    
    public TrackType TrackType { get; set; }

    public long TrackPayloadId { get; set; }
    
    // public IPaymentInfo PaymentInfo { get; set; }
    //        
    // public ITrackNotification Notification { get; set; }
    //        
    // public ICustomerInfo CustomerInfo { get; set; }
}
//
// public interface ICustomerInfo
// {
//     public string UserId { get; set; }
// }
//
// public interface IPaymentInfo
// {
//     public decimal Price { get; set; }
// }

public interface ITrackNotification
{
    public TrackNotificationType NotificationType { get; set; }
}

public enum TrackNotificationType
{
    Email,
    Phone,
    Telegram,
    InApplication,
}