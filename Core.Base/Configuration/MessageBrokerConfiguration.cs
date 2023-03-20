using Core.Base.ConfigurationInterfaces;

namespace Core.Base.Configuration;

public class MessageBrokerConfiguration: BaseConfiguration, IMessageBrokerConfiguration
{
    public MessageBrokerConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }
    
    public string QueName { get => GetConfigFuncString("RABBIT_QUE_NAME"); }
    public string HostName { get => GetConfigFuncString("RABBIT_HOST_NAME"); }
}