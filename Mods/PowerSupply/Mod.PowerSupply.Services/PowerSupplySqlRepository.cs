using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Infrastructure.Services;
using Storage.AppStorage;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Services;

public class PowerSupplySqlRepository: CachedSqlRepositoryService<PowerSupplyEntity, PowerSupplyModel>, IPowerSupplyRepository
{
    public PowerSupplySqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}