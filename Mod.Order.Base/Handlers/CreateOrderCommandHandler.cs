using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Handlers;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, OrderModel>
{
    private readonly IOrderRepository _orderRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;
    
    public async Task<OrderModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.AddAsync(request.Order);
    }
}