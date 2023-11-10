using Core.Base.ConfigurationInterfaces;
using Infrastructure.Services;
using Mod.Order.Models;
using Serilog;

namespace Mod.Order.Services.Listeners;

public class OrderEventCreationListener: ConsumeRabbitMQHostedService<OrderModel>
{
    public OrderEventCreationListener(ILogger logger, IMessageBrokerConfiguration configuration) : base(logger, configuration)
    {
    }
}