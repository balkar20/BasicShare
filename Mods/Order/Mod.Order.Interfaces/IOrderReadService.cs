using Mod.Order.Models;

namespace Mod.Order.Interfaces;

public interface IOrderReadService
{
    Task<List<OrderModel>> GetAllOrders();
}