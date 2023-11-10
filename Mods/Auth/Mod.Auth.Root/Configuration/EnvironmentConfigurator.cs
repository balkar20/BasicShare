using Microsoft.Extensions.DependencyInjection;

namespace Mod.Auth.Root.Configuration;

public class EnvironmentConfigurator
{
    public AuthEnvironmentContext AuthEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(AuthEnvironmentContext context)
    {
        AuthEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => AuthEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => AuthEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => AuthEnvironmentContext.AuthConfiguration);
    }
}