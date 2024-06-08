namespace Apps.EndpointDefinitions.PowerSupplyWebAPI;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
