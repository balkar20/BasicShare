using Data.Base.Objects;
using Mod.Track.EventData.Events.Models;

namespace Mod.Track.EventData.Events;

public class TrackUpdatedPaymentInfoEvent : EventObject
{
    public TrackUpdatedPaymentInfoEvent(Guid id, TrackPaymentInfoEventModel trackPaymentInfoEventModel): base(id)
    {
        this.TrackPaymentInfoEventModel = trackPaymentInfoEventModel;
    }
    
    public TrackPaymentInfoEventModel TrackPaymentInfoEventModel { get; init; }

} 