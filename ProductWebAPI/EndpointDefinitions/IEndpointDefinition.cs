namespace Apps.EndpointDefinitions.ProductWebAPI;

public interfac IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
