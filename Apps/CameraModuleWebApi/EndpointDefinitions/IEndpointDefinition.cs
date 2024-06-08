namespace Apps.EndpointDefinitions.CameraModuleWebAPI;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
