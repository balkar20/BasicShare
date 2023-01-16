﻿


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Repositories;

public class WareHouseProductRepository: CachedRepositoryService<WareHouseProductEntity, WareHouseProductModel>, IWareHouseProductRepository
{
    public WareHouseProductRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): 
        base(apiDbContext, mapper, configurationOptions)
    {
    }
}

