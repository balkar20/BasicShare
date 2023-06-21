namespace Core.Base.ConfigurationInterfaces;

public interface IMessageBrokerConfiguration
{
    public string? QueName { get; }

    public string? HostName { get; }

    public int Port { get; }

    public string? ExchangeName { get; }
    string UserName { get; }
    string Password { get;  }
}