using Core.Base.ConfigurationInterfaces;

namespace Core.Base.Configuration;

public class MessageBrokerConfiguration: BaseConfiguration, IMessageBrokerConfiguration
{
    public MessageBrokerConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }
    
    public string QueName { get => GetConfigFuncString("RABBIT_QUE_NAME"); }
    
    public string ExchangeName { get => GetConfigFuncString("RABBIT_EXCHANGE_NAME"); }
    
    public string HostName { get => GetConfigFuncString("RABBIT_HOST_NAME"); }
    public int Port { get => GetConfigFuncInt("RABBIT_PORT"); }
    public string UserName { get => GetConfigFuncString("RABBIT_USER_NAME"); }
    public string Password { get => GetConfigFuncString("RABBIT_PASSWORD"); }
}