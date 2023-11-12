// using ClientLibrary.Interfaces.Particular;
// using Grpc.Net.Client;
// using IdentityProvider.Shared.Interfaces;
//
// namespace ClientLibrary.Services;
//
// public class OrderCreationService: IOrderCreationService
// {
//     public async Task<CreateOrderReply> CreateOrder()
//     {
//         using var channel = GrpcChannel.ForAddress("http://localhost:5015/");
//         var client = new CreateOrder.CreateOrderClient(channel);
//         return  await client.SayDozeAsync(new CreateOrderRequest()
//         {
//             Name = "Client"
//         });
//     }
// }