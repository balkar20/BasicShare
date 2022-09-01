namespace Apps.EndpointDefinitions.BaseWebApi;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}