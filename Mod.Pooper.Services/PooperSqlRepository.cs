using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Storage.AppStorage;
using Infrastructure.Services;
using Mod.Pooper.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Services;

public class PooperSqlRepository: CachedSqlRepositoryService<PooperEntity, PooperModel>, IPooperRepository
{
    public PooperSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}