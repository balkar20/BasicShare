


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Order.Interfaces;
using Mod.Order.Models;
using StackExchange.Redis;

namespace Mod.Order.Base.Repositories;

public class OrderRepository: CachedRepositoryService<OrderEntity, OrderModel>, IOrderRepository
{
    public OrderRepository(ApiDbContext apiDbContext, IMapper mapper, IOptions<AppConfiguration> configurationOptions):
        base(apiDbContext, mapper, configurationOptions )
    {
    }
}

