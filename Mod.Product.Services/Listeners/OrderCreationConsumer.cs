using EventBus.Events;
using EventBus.Events.Interfaces;
using EventBus.Messages.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
// using Mod.Order.EventData.Events;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Services.Listeners;

public class OrderCreationConsumer: IConsumer<OrderCreatedEvent>
{
    public readonly ILogger<OrderCreationConsumer> _logger;
    private readonly IServiceScopeFactory scopeFactory;
    private readonly IProductRepository _productRepository;

    public OrderCreationConsumer(ILogger<OrderCreationConsumer> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        // using var scope = scopeFactory.CreateScope();
        //  var repo = scope.ServiceProvider.GetRequiredService<IProductRepository>();

        try
        {
            await _productRepository.AddAsync(new ProductModel()
            {
                // Id = Guid.NewGuid(),
                Name = $"CustomerId is {context.Message.CorrelationId}",
                Description = $"CorId is  {context.Message.CorrelationId}"
            });
            
            await context.Publish<IStockReservedEvent>(new StockReservedEvent()
            {   
                CorrelationId = context.Message.CorrelationId,
                OrderItemList = new List<OrderItem>()
            });

            _logger.LogInformation(context.Message.CorrelationId.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
         
    }
}