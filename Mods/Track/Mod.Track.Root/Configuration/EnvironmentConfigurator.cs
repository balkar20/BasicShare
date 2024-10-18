using Microsoft.Extensions.DependencyInjection;

namespace Mod.Track.Root.Configuration;

public class EnvironmentConfigurator
{
    public TrackEnvironmentContext TrackEnvironmentContext { get; init; }
    
    public EnvironmentConfigurator(TrackEnvironmentContext context)
    {
        TrackEnvironmentContext = context;
    }

    public void ConfigureEnvironment(IServiceCollection services)
    {
        services.AddSingleton(x => TrackEnvironmentContext.AppConfiguration);
        services.AddSingleton(x => TrackEnvironmentContext.DocumentDataConfiguration);
        services.AddSingleton(x => TrackEnvironmentContext.MessageBrokerConfiguration);
        services.AddSingleton(x => TrackEnvironmentContext.TrackApiConfiguration);
    }
}