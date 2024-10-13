using Mod.Track.Models.Enums;

namespace Mod.Track.Models;

public class TrackModel
{
    public Guid Id { get; set; }
    
    public string Description { get; set; }
    
    public TrackType TrackType { get; set; }
    
    public TrackStatus TrackStatus { get; set; }

    public long TrackPayloadId { get; set; }
    
    public TrackPaymentInfoModel TrackPaymentInfoModel { get; set; }
           
    public TrackNotificationModel NotificationModel { get; set; }
           
    public string CustomerId { get; set; }
    
    public List<TrackItemModel> TrackItemList { get; set; }
}