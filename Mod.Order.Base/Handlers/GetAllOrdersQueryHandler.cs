// using MediatR;
// using Mod.Order.Base.Queries;
// using Mod.Order.Interfaces;
// using Mod.Order.Models;
//
// namespace Mod.Order.Base.Handlers;
//
// public class GetAllOrdersQueryHandler: IRequestHandler<GetAllOrdersQuery, List<OrderModel>>
// {
//     private readonly IOrderRepository _orderRepository;
//     private readonly IOrderService _orderService;
//
//     public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IOrderService orderService)
//     {
//         _orderRepository = orderRepository;
//         _orderService = orderService;
//     }
//     
//     public async Task<List<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
//     {
//         return await _orderService.GetAllOrders();
//     }
// }