using Microsoft.Extensions.DependencyInjection;

namespace Mod.Order.Root.Configuration;

public class EnvironmentConfigurator
{
    public OrderEnvironmentContext OrderEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(OrderEnvironmentContext context)
    {
        OrderEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => OrderEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => OrderEnvironmentContext.DocumentDataConfiguration);
        services.AddSingleton(x => OrderEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => OrderEnvironmentContext.OrderApiConfiguration);
    }
}