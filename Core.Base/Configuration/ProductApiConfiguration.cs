using Core.Base.ConfigurationInterfaces;

namespace Core.Base.Configuration;

public class ProductApiConfiguration: BaseConfiguration, IProductApiConfiguration
{
    
    public ProductApiConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }

    public string? ApiName { get => GetConfigFuncString("API_NAME"); }

    public string? ApiVersion { get => GetConfigFuncString("API_VERSION"); }

    public string? IdentityServerBaseUrl { get => GetConfigFuncString("IDENTITY_SERVER_BASE_URL"); }

    public string? ApiBaseUrl { get => GetConfigFuncString("API_BASE_URL"); }

    public string? OidcSwaggerUiClientId { get => GetConfigFuncString("OIDC_SWAGGER_UI_CLIENT_ID"); }

    public bool RequireHttpsMetadata { get => GetConfigFuncBool("REQUIRE_HTTPS_METADATA"); }

    public string? OidcApiName { get => GetConfigFuncString("LOKI_USER_NAME"); }

    public string? AdministrationRole { get => GetConfigFuncString("ADMINISTRATION_ROLE"); }

    public bool CorsAllowAnyOrigin { get => GetConfigFuncBool("CORS_ALLOW_ANY_ORIGIN"); }

}