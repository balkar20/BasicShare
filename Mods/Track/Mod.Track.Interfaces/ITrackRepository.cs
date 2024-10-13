using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.Track.Models;

namespace Mod.Track.Interfaces;

public interface ITrackRepository: IRepository<TrackEntity, TrackModel>
{
}