using Data.Base.Objects;
using Mod.Track.EventData.Events.Models;

namespace Mod.Track.EventData.Events;

public class TrackUpdatedEvent : EventObject
{
    public TrackUpdatedEvent(string Description, long TrackPayloadId, TrackPaymentInfoEventModel trackPaymentInfoEventModel, TrackNotificationEventModel notificationEventModel, Guid CustomerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.TrackPayloadId = TrackPayloadId;
        this.TrackPaymentInfoEventModel = trackPaymentInfoEventModel;
        this.NotificationEventModel = notificationEventModel;
        this.CustomerId = CustomerId;
    }

    public string Description { get; init; }
    public long TrackPayloadId { get; init; }
    public TrackPaymentInfoEventModel TrackPaymentInfoEventModel { get; init; }
    public TrackNotificationEventModel NotificationEventModel { get; init; }
    public Guid CustomerId { get; init; }

    public void Deconstruct(out string Description, out long TrackPayloadId, out TrackPaymentInfoEventModel trackPaymentInfoEventModel, out TrackNotificationEventModel notificationEventModel, out Guid CustomerId)
    {
        Description = this.Description;
        TrackPayloadId = this.TrackPayloadId;
        trackPaymentInfoEventModel = this.TrackPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }
} 