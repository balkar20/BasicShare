using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Interfaces;

public interface IOrderRepository: IRepository<OrderEntity, OrderModel>
{
}