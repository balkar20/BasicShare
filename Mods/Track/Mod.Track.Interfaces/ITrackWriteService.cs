using Mod.Track.Models;

namespace Mod.Track.Interfaces;

public interface ITrackWriteService
{
        
    Task<TrackIdModel> CreateTrack(TrackModel order);
    
    Task UpdateTrackNotification(TrackNotificationModel orderNotificationModel);

    Task UpdateTrackPaymentInfo(TrackPaymentInfoModel orderNotificationModel);
}