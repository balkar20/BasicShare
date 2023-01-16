namespace Apps.EndpointDefinitions.ProductWebAPI;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}