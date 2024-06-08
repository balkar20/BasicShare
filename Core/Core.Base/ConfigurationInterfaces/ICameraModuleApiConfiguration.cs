namespace Core.Base.ConfigurationInterfaces;

public interface ICameraModuleApiConfiguration
{
    public string? ApiName { get; }

    public string? ApiVersion { get; }

    public string? IdentityServerBaseUrl { get; }

    public string? ApiBaseUrl { get; }

    public string? OidcSwaggerUiClientId { get; }

    public bool RequireHttpsMetadata { get; }

    public string? OidcApiName { get; }

    public string? AdministrationRole { get; }

    public bool CorsAllowAnyOrigin { get; }
}
