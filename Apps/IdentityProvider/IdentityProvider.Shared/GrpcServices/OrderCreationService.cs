using Grpc.Core;

namespace IdentityProvider.Shared.GrpcServices;

public class OrderCreationService: CreateOrder.CreateOrderBase
{
    public override async Task<CreateOrderReply> SayDoze(CreateOrderRequest request, ServerCallContext context)
    {
        var op = request.Name;
        var reply = new CreateOrderReply()
        {
            Message = $"Your Doze here my friend =  {op}"
        };
        return reply;
    }
}