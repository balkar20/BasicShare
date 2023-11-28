using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mod.Shipment.Root.AppServices;
using Mod.Shipment.Root.Configuration;
using Mod.Shipment.Root.ExtenalServices;

namespace Mod.Shipment.Root;

public class StartupConfigurator
{
    private readonly IConfiguration _configuration;
    private readonly IServiceCollection _serviceCollection;
    private readonly WebApplicationBuilder _builder;

    public StartupConfigurator(IConfiguration configuration, WebApplicationBuilder builder)
    {
        _configuration = configuration;
        _serviceCollection = builder.Services;
        _builder = builder;
    }

    public void Configure()
    {
        var appServicesConfigurator = new ModShipmentServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new ShipmentEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModShipmentExternalServicesConfigurator(_builder, environmentConfigurator.ShipmentEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}