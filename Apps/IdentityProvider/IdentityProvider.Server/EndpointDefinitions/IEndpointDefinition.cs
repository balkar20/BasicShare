namespace Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}