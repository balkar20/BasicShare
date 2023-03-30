// using MediatR;
// using Mod.Order.Base.Commands;
// using Mod.Order.Interfaces;
// using Mod.Order.Models;
//
// namespace Mod.Order.Base.Handlers;
//
// public class UpdateOrderCommandHandler: IRequestHandler<UpdateOrderCommand, OrderModel>
// {
//     private readonly IOrderRepository _orderRepository;
//     
//     public UpdateOrderCommandHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;
//
//     public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
//     {
//         return await _orderRepository.UpdateAsync(request.Order);
//     }
// }