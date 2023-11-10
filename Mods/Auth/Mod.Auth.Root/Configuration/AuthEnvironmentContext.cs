using Core.Auh.Configuration;
using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.Auth.Root.Configuration;

public class AuthEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public AuthConfiguration AuthConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public AuthEnvironmentContext(Func<string, string> getConfigFunc)
    {
        AppConfiguration = new AppConfiguration(getConfigFunc);
        AuthConfiguration = new AuthConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}