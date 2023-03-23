using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Root.AppServices;
using Mod.Product.Root.Configuration;
using Mod.Product.Root.ExtenalServices;

namespace Mod.Product.Root;

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
        var appServicesConfigurator = new ModProductServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new ProductEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModProductExternalServicesConfigurator(_builder, environmentConfigurator.ProductEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}