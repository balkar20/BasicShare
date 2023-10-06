using MassTransit;

namespace Mod.Product.Services.Consumer;

public class OrderCreationConsumer:IConsumer<OrderCreatedMessage>
{
    public Task Consume(ConsumeContext<OrderCreatedMessage> context)
    {
        throw new NotImplementedException();
    }
}

public record OrderCreatedMessage(string Message);