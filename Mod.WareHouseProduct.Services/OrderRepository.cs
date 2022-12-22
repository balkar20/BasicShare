


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;
using StackExchange.Redis;

namespace Mod.WareHouseProduct.Base.Repositories;

public class WareHouseProductRepository: CachedRepositoryService<WareHouseProductEntity, WareHouseProductModel>, IWareHouseProductRepository
{
    public WareHouseProductRepository(ApiDbContext apiDbContext, IMapper mapper, IOptions<AppConfiguration> configurationOptions): 
        base(apiDbContext, mapper, configurationOptions)
    {
    }
}

