using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using ModOrder.Models;

namespace Mod.Order.Base.Handlers;

public class UpdateOrderCommandHandler: IRequestHandler<UpdateOrderCommand, OrderModel>
{
    private readonly IOrderRepository _OrderRepository;
    
    public UpdateOrderCommandHandler(IOrderRepository OrderRepository) => _OrderRepository = OrderRepository;

    public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        return await _OrderRepository.UpdateAsync(request.Order);
    }
}