namespace Apps.EndpointDefinitions.MotorControlsModuleWebAPI;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
