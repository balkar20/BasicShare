


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Storage.AppStorage;
using Infrastructure.Services;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Repositories;

public class WareHouseProductSqlRepository: CachedSqlRepositoryService<WareHouseProductEntity, WareHouseProductModel>, IWareHouseProductRepository
{
    public WareHouseProductSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): 
        base(apiDbContext, mapper, configurationOptions)
    {
    }
}

