


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Repositories;

public class OrderRepository: CachedRepositoryService<OrderEntity, OrderModel>, IOrderRepository
{
    public OrderRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions):
        base(apiDbContext, mapper, configurationOptions )
    {
    }
}

