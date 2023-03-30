using Core.Base.Configuration;

namespace Core.Auh.Configuration
{
    public class AuthConfiguration: BaseConfiguration
    {
        
        public const string HostConfiguration = "AuthConfiguration";
        
        
        public AuthConfiguration(Func<string, string> getConfigFunc) : base(getConfigFunc)
        {
        }

        public int ExpiryInMinutes { get => GetConfigFuncInt("EXPIRY_IN_MINUTES"); }
        public string ValidIssuer { get => GetConfigFuncString("VALID_ISSUER"); }
        public string ValidAudience { get => GetConfigFuncString("VALID_AUDIENCE"); }
        public string SecurityKey { get => GetConfigFuncString("SECURITY_KEY"); }
    }
}
