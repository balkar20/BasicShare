using Infrastructure.Interfaces;
using Mod.Order.EventData.Aggregates;
using Mod.Order.EventData.Events;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Services;

public class OrderWriteService: IOrderWriteService
{
    private readonly IMessageBusService _messageBusService;
    private readonly IOrderRepository _orderRepository;
    private readonly IAggregateRepository<OrderAggregate> _oerderAggregateRepository;

    public OrderWriteService(IMessageBusService messageBusService, IOrderRepository orderRepository)
    {
        _messageBusService = messageBusService;
        _orderRepository = orderRepository;
    }

    public async Task UpdateOrder(OrderModel order)
    {
        var aggregate = new OrderAggregate(order);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task CreateOrder(OrderModel order)
    {
        var aggregate = new OrderAggregate(order);
        await _oerderAggregateRepository.Save(aggregate, -1);
        // var orderCreatedEvent = new OrderCreatedEvent();
        // _messageBusService.PublishMessage(orderCreatedEvent);
    }
}