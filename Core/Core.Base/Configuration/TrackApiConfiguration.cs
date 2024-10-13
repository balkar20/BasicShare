using Core.Base.ConfigurationInterfaces;

namespace Core.Base.Configuration;

public class TrackApiConfiguration: BaseConfiguration, ITrackApiConfiguration
{
    public const string AuthConfiguration = "AuthConfiguration";
    
    public string? ApiName { get; set; }

    public string? ApiVersion { get; set; }

    public string? IdentityServerBaseUrl { get; set; }

    public string? ApiBaseUrl { get; set; }

    public string? OidcSwaggerUiClientId { get; set; }

    public bool RequireHttpsMetadata { get; set; }

    public string? OidcApiName { get; set; }

    public string? AdministrationRole { get; set; }

    public bool CorsAllowAnyOrigin { get; set; }

    public string[]? CorsAllowOrigins { get; set; }

    public TrackApiConfiguration(Func<string, string> getConfigFunc) : base(getConfigFunc)
    {
    }
}