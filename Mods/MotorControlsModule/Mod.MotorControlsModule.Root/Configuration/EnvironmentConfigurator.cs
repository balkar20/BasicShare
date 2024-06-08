using Microsoft.Extensions.DependencyInjection;

namespace Mod.MotorControlsModule.Root.Configuration;

public class EnvironmentConfigurator
{
    public MotorControlsModuleEnvironmentContext MotorControlsModuleEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(MotorControlsModuleEnvironmentContext context)
    {
        MotorControlsModuleEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => MotorControlsModuleEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => MotorControlsModuleEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => MotorControlsModuleEnvironmentContext.MotorControlsModuleApiConfiguration);
    }
}