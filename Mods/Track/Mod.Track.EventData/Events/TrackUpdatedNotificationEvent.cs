using Data.Base.Objects;
using Mod.Track.EventData.Events.Models;

namespace Mod.Track.EventData.Events;

public class TrackUpdatedNotificationEvent : EventObject
{
    public TrackUpdatedNotificationEvent(Guid id, TrackNotificationEventModel notificationEventModel): base(id)
    {
        this.NotificationEventModel = notificationEventModel;
    }
    
    public TrackNotificationEventModel NotificationEventModel { get; init; }

} 