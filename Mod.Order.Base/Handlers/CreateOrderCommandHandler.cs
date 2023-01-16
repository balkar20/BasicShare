using Infrastructure.Interfaces;
using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Handlers;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, OrderModel>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IRabitMQProducer _rabbitMqProducer;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IRabitMQProducer rabbitMqProducer)
    {
        _orderRepository = orderRepository;
        _rabbitMqProducer = rabbitMqProducer;
    }

    public async Task<OrderModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var createdOrder =  await _orderRepository.AddAsync(request.Order);
        _rabbitMqProducer.SendMessage(createdOrder);
        return createdOrder;
    }
}