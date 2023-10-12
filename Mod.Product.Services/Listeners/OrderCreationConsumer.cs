using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mod.Order.EventData.Events;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Services.Listeners;

public class OrderCreationConsumer: IConsumer<OrderCreatedEvent>
{
    public readonly ILogger<OrderCreationConsumer> _logger;
    private readonly IServiceScopeFactory scopeFactory;

    public OrderCreationConsumer(ILogger<OrderCreationConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        using var scope = scopeFactory.CreateScope();
         var repo = scope.ServiceProvider.GetRequiredService<IProductRepository>();

         await repo.AddAsync(new ProductModel()
         {
             Name = $"BusinessChannelAlias For {context.Message.Description}",
             Description = $"ProductAlias For {context.Message.Description}"
         });
         
        _logger.LogInformation(context.Message.Description);
    }
}