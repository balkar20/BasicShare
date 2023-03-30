using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Mod.Pooper.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Services;

public class PooperRepository: CachedRepositoryService<PooperEntity, PooperModel>, IPooperRepository
{
    public PooperRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}