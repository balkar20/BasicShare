// using Core.Transfer;
// using Infrastructure.Interfaces;
// using MediatR;
// using Mod.Order.Base.Commands;
// using Mod.Order.Interfaces;
//
// namespace Mod.Order.Base.Handlers;
//
// public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, BaseResponseResult>
// {
//     // private readonly IOrderRepository _orderRepository;
//     private readonly IMessageBusService _messageBusService;
//     private IOrderWriteService _orderSevice;
//
//     // public CreateOrderCommandHandler(IOrderRepository orderRepository, IRabbitMqProducer rabbitMqProducer)
//     public CreateOrderCommandHandler(IMessageBusService messageBusService, IOrderWriteService orderSevice)
//     {
//         // _orderRepository = orderRepository;
//         _messageBusService = messageBusService;
//         _orderSevice = orderSevice;
//     }
//
//     public async Task<BaseResponseResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
//     {
//         var result = new BaseResponseResult()
//         {
//             IsSuccess = false
//         };
//
//         await _orderSevice.CreateOrder(request.Order);
//         result.IsSuccess = true;
//
//         
//         return result;
//     }
// }