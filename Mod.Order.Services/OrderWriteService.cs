using AutoMapper;
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
    protected readonly IMapper _mapper;
    

    public OrderWriteService(IMessageBusService messageBusService, IOrderRepository orderRepository, IMapper mapper)
    {
        _messageBusService = messageBusService;
        _orderRepository = orderRepository;
        _mapper = mapper;
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
    }
}