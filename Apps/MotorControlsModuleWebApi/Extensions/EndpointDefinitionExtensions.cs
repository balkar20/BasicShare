using Apps.EndpointDefinitions.MotorControlsModuleWebAPI;

namespace Apps.MotorControlsModuleWebAPI.Extensions;

public static class EndpointDefinitionExtensions
{
    public static void AddEndpointDefinitions(
        this IServiceCollection services, params Type[] scanMarkers)
    {
        var endpointDefinitions = new List<IEndpointDefinition>();

        foreach (var marker in scanMarkers)
        {
            endpointDefinitions.AddRange(
                marker.Assembly.ExportedTypes
                    .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());
        }

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineServices(services);
        }

        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this IApplicationBuilder applicationBuilder)
    {
        var definitions = applicationBuilder.ApplicationServices.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
        
        foreach (var endpointDefinition in definitions)
        {
            endpointDefinition.DefineEndpoints((WebApplication)applicationBuilder);
        }
    }
}