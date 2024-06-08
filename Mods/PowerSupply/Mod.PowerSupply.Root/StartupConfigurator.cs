using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mod.PowerSupply.Root.AppServices;
using Mod.PowerSupply.Root.Configuration;
using Mod.PowerSupply.Root.ExtenalServices;

namespace Mod.PowerSupply.Root;

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
        var appServicesConfigurator = new ModPowerSupplyServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new PowerSupplyEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModPowerSupplyExternalServicesConfigurator(_builder, environmentConfigurator.PowerSupplyEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}