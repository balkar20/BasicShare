using Microsoft.Extensions.DependencyInjection;

namespace Mod.PowerSupply.Root.Configuration;

public class EnvironmentConfigurator
{
    public PowerSupplyEnvironmentContext PowerSupplyEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(PowerSupplyEnvironmentContext context)
    {
        PowerSupplyEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => PowerSupplyEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => PowerSupplyEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => PowerSupplyEnvironmentContext.PowerSupplyApiConfiguration);
    }
}