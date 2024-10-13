using Mod.Track.Models;

namespace Mod.Track.Interfaces;

public interface ITrackReadService
{
    Task<List<TrackModel>> GetAllTracks();
}