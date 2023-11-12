// using ClientLibrary;
// using Grpc.Core;
// using IdentityProvider.Server;
//
// namespace IdentityProvider.Server.GrpcServices;
//
// public class OrderService:CreateOrder.CreateOrderBase
// {
//     private readonly ILogger<OrderService> _logger;
//
//     public OrderService(ILogger<OrderService> logger)
//     {
//         _logger = logger;
//     }
//
//     public override Task<CreateOrderReply> SayDoze(CreateOrderRequest request, ServerCallContext context)
//     {
//         return Task.FromResult(new CreateOrderReply
//         {
//             Message = "Hello From Doze to " + request.Name
//         });
//     }
// }