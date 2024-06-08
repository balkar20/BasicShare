using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mod.MotorControlsModule.Root.AppServices;
using Mod.MotorControlsModule.Root.Configuration;
using Mod.MotorControlsModule.Root.ExtenalServices;

namespace Mod.MotorControlsModule.Root;

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
        var appServicesConfigurator = new ModMotorControlsModuleServicesConfigurator(_serviceCollection);
        var environmentConfigurator = new EnvironmentConfigurator(new MotorControlsModuleEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModMotorControlsModuleExternalServicesConfigurator(_builder, environmentConfigurator.MotorControlsModuleEnvironmentContext);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_serviceCollection);
        externalServicesConfigurator.Configure();
    }
}