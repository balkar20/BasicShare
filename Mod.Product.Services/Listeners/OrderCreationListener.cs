using Core.Base.ConfigurationInterfaces;
using Core.Transfer.Mods.Order;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Interfaces;
using Mod.Product.Models;
using Serilog;

namespace Mod.Product.Services.Listeners;

public class OrderCreationListener:  ConsumeRabbitMQHostedService<OrderModel>
{
    private readonly IServiceScopeFactory scopeFactory;

    public OrderCreationListener(ILogger logger, IMessageBrokerConfiguration configuration, IServiceScopeFactory scopeFactory) : base(logger, configuration)
    {
        this.scopeFactory = scopeFactory;
        handler = Handler;
    }

    private async void Handler(OrderModel orderModel)
    {
        await SaveProductFromOrder(orderModel);
    }

    private async Task SaveProductFromOrder(OrderModel orderModel)
    {
        using (var scope = scopeFactory.CreateScope())
        {
            var repo = scope.ServiceProvider.GetRequiredService<IProductRepository>();

            await repo.AddAsync(new ProductModel()
            {
                Name = $"BusinessChannelAlias For {orderModel.Description}",
                Description = $"ProductAlias For {orderModel.Description}"
            });

            _logger.Information("ProductModel for {OrderModelDescription} created", orderModel.Description);
        }
    }
}