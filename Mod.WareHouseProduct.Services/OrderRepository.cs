


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Db;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;
using Services;

namespace Mod.WareHouseProduct.Base.Repositories;

public class WareHouseProductRepository: CachedRepositoryService<WareHouseProductEntity, WareHouseProductModel>, IWareHouseProductRepository
{
    public WareHouseProductRepository(ApiDbContext apiDbContext, IMapper mapper, IDistributedCache cache,
    IOptions<AppConfiguration> configurationOptions): base(apiDbContext, mapper, cache, configurationOptions )
    {
    }
}

