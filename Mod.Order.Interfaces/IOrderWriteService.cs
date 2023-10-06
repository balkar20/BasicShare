using Mod.Order.Models;

namespace Mod.Order.Interfaces;

public interface IOrderWriteService
{
    Task UpdateOrder(OrderModel order);
    
    Task CreateOrder(OrderModel order);
}