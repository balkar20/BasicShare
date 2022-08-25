using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Options;
using Mod.Order.Interfaces;
using Mod.Order.Models;
using Serilog;

namespace Mod.Order.Base.Repositories;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly ILogger _logger;
    private readonly OrderApiConfiguration _configuration;

    public OrderService(
        ILogger logger,
        IOptions<OrderApiConfiguration> options,
        IOrderRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = options.Value;
    }

    public async Task<List<OrderModel>> GetAllOrders()
    {
        var orders =  await _repository.GetAllMappedToModelAsync<OrderEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return orders.ToList();
    }
}