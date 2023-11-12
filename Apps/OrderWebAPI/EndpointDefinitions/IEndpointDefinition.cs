namespace Apps.EndpointDefinitions.OrderWebAPI;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
