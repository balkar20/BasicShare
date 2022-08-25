using Mod.Order.Models;

namespace Mod.Order.Interfaces;

public interface IOrderService
{
    Task<List<OrderModel>> GetAllOrders();
}