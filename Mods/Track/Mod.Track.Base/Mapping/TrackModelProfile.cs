using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Track.Models;

namespace Mod.Track.Base.Mapping;

public class TrackModelProfile: Profile
{
    public TrackModelProfile()
    {
        CreateMap<TrackModel, TrackEntity>().ReverseMap();
    }
}