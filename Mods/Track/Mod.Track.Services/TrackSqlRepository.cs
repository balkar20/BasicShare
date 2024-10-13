


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Storage.AppStorage;
using Infrastructure.Services;
using Mod.Track.Interfaces;
using Mod.Track.Models;

namespace Mod.Track.Base.Repositories;

public class TrackSqlRepository: CachedSqlRepositoryService<TrackEntity, TrackModel>, ITrackRepository
{
    public TrackSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions):
        base(apiDbContext, mapper, configurationOptions )
    {
    }
}

