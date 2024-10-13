using Data.Base.Objects;

namespace Mod.Track.EventData.Events;

public class TrackCanceledEvent:EventObject
{
    public TrackCanceledEvent(Guid id) : base(id)
    {
    }
}