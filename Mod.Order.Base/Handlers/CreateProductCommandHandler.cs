using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using ModOrder.Models;

namespace Mod.Order.Base.Handlers;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, OrderModel>
{
    private readonly IOrderRepository _OrderRepository;
    public CreateOrderCommandHandler(IOrderRepository OrderRepository) => _OrderRepository = OrderRepository;
    
    public async Task<OrderModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await _OrderRepository.AddAsync(request.Order);
    }
}