using EventBus.Events;
using EventBus.Events.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Services.Consumers;

public class OrderCreationConsumer: IConsumer<OrderCreatedEvent>
{
    public readonly ILogger<OrderCreationConsumer> _logger;
    private readonly IServiceScopeFactory scopeFactory;
    private readonly IMotorControlsModuleRepository _productRepository;

    public OrderCreationConsumer(ILogger<OrderCreationConsumer> logger, IMotorControlsModuleRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        try
        {
            await _productRepository.AddAsync(new MotorControlsModuleModel()
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