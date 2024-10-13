using Data.Base.Objects;
using Mod.Track.EventData.Enums;
using Mod.Track.EventData.Events.Models;

// using Data.Tracking.Objects;
// using TrackNotification = Mod.Track.EventData.Events.Models.TrackNotification;
// using PaymentInfo = Mod.Track.EventData.Events.Models.PaymentInfo;

namespace Mod.Track.EventData.Events;

public class TrackCreatedEvent : EventObject
{
    public TrackCreatedEvent(string Description, TrackType TrackType, long paymentAccountId, TrackPaymentInfoEventModel trackPaymentInfoEventModel, TrackNotificationEventModel notificationEventModel, string customerId): base(Guid.NewGuid())
    {
        this.Description = Description;
        this.TrackType = TrackType;
        this.PaymentAccountId = paymentAccountId;
        this.TrackPaymentInfoEventModel = trackPaymentInfoEventModel;
        this.NotificationEventModel = notificationEventModel;
        this.CustomerId = customerId;
    }

    public TrackCreatedEvent(): base(Guid.NewGuid())
    {
        
    }

    public string Description { get; init; }
    public TrackType TrackType { get; init; }
    public long PaymentAccountId { get; init; }
    public TrackPaymentInfoEventModel TrackPaymentInfoEventModel { get; init; }
    public TrackNotificationEventModel NotificationEventModel { get; init; }
    public string CustomerId { get; init; }

    public void Deconstruct(out string Description, out TrackType TrackType, out long TrackProductId, out TrackPaymentInfoEventModel trackPaymentInfoEventModel, out TrackNotificationEventModel notificationEventModel, out string CustomerId)
    {
        Description = this.Description;
        TrackType = this.TrackType;
        TrackProductId = this.PaymentAccountId;
        trackPaymentInfoEventModel = this.TrackPaymentInfoEventModel;
        notificationEventModel = this.NotificationEventModel;
        CustomerId = this.CustomerId;
    }
} 