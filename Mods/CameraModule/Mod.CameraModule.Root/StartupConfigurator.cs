using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mod.CameraModule.Root.AppServices;
using Mod.CameraModule.Root.Configuration;
using Mod.CameraModule.Root.ExtenalServices;

namespace Mod.CameraModule.Root;

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
        var appServicesConfigurator = new ModCameraModuleServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new CameraModuleEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModCameraModuleExternalServicesConfigurator(_builder, environmentConfigurator.CameraModuleEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}