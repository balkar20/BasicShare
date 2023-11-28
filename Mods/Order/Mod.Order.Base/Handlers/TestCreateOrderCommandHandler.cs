// using AutoMapper;
// using Core.Transfer;
// using Data.Base.Objects;
// using EventBus.Constants;
// using EventBus.Messages;
// using EventBus.Messages.Interfaces;
// using Infrastructure.Interfaces;
// using Infrastructure.Interfaces.MassTransit;
// using MassTransitBase;
// using MediatR;
// using Mod.Order.Base.Commands;
// using Mod.Order.EventData.Enums;
// using Mod.Order.EventData.Events;
// using Mod.Order.Interfaces;
//
// namespace Mod.Order.Base.Handlers;
//
// public class TestCreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, BaseResponseResult>
// {
//     // private readonly IOrderRepository _orderRepository;
//     private readonly IMassTransitService _massTransitService;
//     private readonly IMapper _mapper;
//
//     // public CreateOrderCommandHandler(IOrderRepository orderRepository, IRabbitMqProducer rabbitMqProducer)
//     public TestCreateOrderCommandHandler(IMassTransitService massTransitService, IMapper mapper)
//     {
//         // _orderRepository = orderRepository;
//         // _messageBusService = messageBusService;
//         // _orderSevice = orderSevice;
//         _massTransitService = massTransitService;
//         _mapper = mapper;
//     }
//
//     public async Task<BaseResponseResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
//     {
//         var result = new BaseResponseResult()
//         {
//             IsSuccess = false
//         };
//         
//         result.IsSuccess = true;
//         var orderCreatedEvent = new OrderCreatedEvent()
//         {
//             CustomerId = "kjkjkj",
//             OrderType = OrderType.Product,
//             PaymentAccountId = 1,
//             Version = 2
//         };
//         var mapped = _mapper.Map<IBaseSagaMessage>(orderCreatedEvent);
//         var random = new Random();
//         var message = new CreateOrderMessage()
//         {
//             OrderId = Guid.NewGuid(),
//             CustomerId = random.Next(1, 10000).ToString(),
//             PaymentAccountId = random.Next(1, 10000).ToString(),
//             TotalPrice = 50
//         };
//         
//         var mapped2 = _mapper.Map<IBaseSagaMessage>(message);
//         // var mty = mapped2.GetType();
//         // var mapped3 = _mapper.Map(message, mty);
//         var o = mapped switch
//         {
//             ICreateOrderMessage create => create,
//             _ => mapped
//         };
//         
//         ICreateOrderMessage? createOrderMessage = mapped as ICreateOrderMessage;
//         await _massTransitService.Send(mapped2, QueuesConsts.CreateOrderMessageQueueName);
//         // result.IsSuccess = true;
//
//         
//         return result;
//     }
// }