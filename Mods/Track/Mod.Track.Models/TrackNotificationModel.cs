using Mod.Track.Models.Enums;

namespace Mod.Track.Models;

public class TrackNotificationModel: TrackIdModel
{
    public NotificationType NotificationType { get; set; }
}