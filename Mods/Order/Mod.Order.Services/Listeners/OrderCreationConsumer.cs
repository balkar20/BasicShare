using MassTransit;
using Microsoft.Extensions.Logging;
using Mod.Order.EventData.Events;

namespace Mod.Order.Services.Listeners;

// public class OrderCreationConsumer : IConsumer<OrderCreatedEvent>
// {
//     public readonly ILogger<OrderCreationConsumer> _logger;
//
//     public OrderCreationConsumer(ILogger<OrderCreationConsumer> logger)
//     {
//         _logger = logger;
//     }
//
//     public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
//     {
//         _logger.LogInformation(context.Message.Description);
//     }
// }