using Data.Base.Objects;

namespace Mod.Track.EventData.Events;

public class TrackCompletedEvent : EventObject
{
    public TrackCompletedEvent(Guid id) : base(id)
    {
    }
}