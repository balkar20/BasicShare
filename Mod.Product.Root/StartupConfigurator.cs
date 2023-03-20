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

    public StartupConfigurator(IConfiguration configuration, IServiceCollection serviceCollection)
    {
        _configuration = configuration;
        _serviceCollection = serviceCollection;
    }

    public void Configure()
    {
        var appServicesConfigurator = new ModProductServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new ProductEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModProductExternalServicesConfigurator(_serviceCollection, environmentConfigurator.ProductEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}