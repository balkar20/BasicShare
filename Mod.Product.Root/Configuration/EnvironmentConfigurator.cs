using Microsoft.Extensions.DependencyInjection;

namespace Mod.Product.Root.Configuration;

public class EnvironmentConfigurator
{
    public ProductEnvironmentContext ProductEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(ProductEnvironmentContext context)
    {
        ProductEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => ProductEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => ProductEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => ProductEnvironmentContext.ProductApiConfiguration);
    }
}