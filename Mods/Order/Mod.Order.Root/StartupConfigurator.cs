using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.Root.AppServices;
using Mod.Order.Root.Configuration;
using Mod.Order.Root.ExtenalServices;

namespace Mod.Order.Root;

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
        var appServicesConfigurator = new ModOrderServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new OrderEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModOrderExternalServicesConfigurator(_builder, environmentConfigurator.OrderEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}