using Microsoft.Extensions.DependencyInjection;

namespace Mod.CameraModule.Root.Configuration;

public class EnvironmentConfigurator
{
    public CameraModuleEnvironmentContext CameraModuleEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(CameraModuleEnvironmentContext context)
    {
        CameraModuleEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => CameraModuleEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => CameraModuleEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => CameraModuleEnvironmentContext.CameraModuleApiConfiguration);
    }
}