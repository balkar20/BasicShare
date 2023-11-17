using Microsoft.Extensions.DependencyInjection;

namespace Mod.Shipment.Root.Configuration;

public class EnvironmentConfigurator
{
    public ShipmentEnvironmentContext ShipmentEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(ShipmentEnvironmentContext context)
    {
        ShipmentEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => ShipmentEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => ShipmentEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => ShipmentEnvironmentContext.ShipmentApiConfiguration);
    }
}