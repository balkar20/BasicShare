


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Repositories;

public class OrderSqlRepository: CachedSqlRepositoryService<OrderEntity, OrderModel>, IOrderRepository
{
    public OrderSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions):
        base(apiDbContext, mapper, configurationOptions )
    {
    }
}

