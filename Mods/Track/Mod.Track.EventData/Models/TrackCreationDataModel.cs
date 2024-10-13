using MassTransit;
using Mod.Track.EventData.Enums;

namespace Mod.Track.EventData.Events.Models;

public class TrackCreationDataModel
{
    // public TrackCreationDataModel(string Description, TrackType TrackType, long TrackPayloadId, TrackPaymentInfoEventModel TrackPaymentInfoEventModel,
    //     TrackNotificationEventModel NotificationEventModel, string CustomerId)
    // {
    //     this.Description = Description;
    //     this.TrackType = TrackType;
    //     this.TrackPayloadId = TrackPayloadId;
    //     this.TrackPaymentInfoEventModel = TrackPaymentInfoEventModel;
    //     this.NotificationEventModel = NotificationEventModel;
    //     this.CustomerId = CustomerId;
    // }

    public string Description { get; set; }
    public TrackType TrackType { get; set; }
    public long TrackPayloadId { get; set; }
    public TrackPaymentInfoEventModel TrackPaymentInfoEventModel { get; set; }
    public TrackNotificationEventModel NotificationEventModel { get; set; }
    public string CustomerId { get; set; }

    public void Deconstruct(out string Description, out TrackType TrackType, out long TrackPayloadId, out TrackPaymentInfoEventModel trackPaymentInfoEventModel, out TrackNotificationEventModel notificationEventModel, out string CustomerId)
    {
        Description = this.Description;
        TrackType = this.TrackType;
        TrackPayloadId = this.TrackPayloadId;
        trackPaymentInfoEventModel = this.TrackPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }
}
