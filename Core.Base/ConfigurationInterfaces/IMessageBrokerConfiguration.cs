namespace Core.Base.ConfigurationInterfaces;

public interface IMessageBrokerConfiguration
{
    public string? QueName { get; }

    public string? HostName { get; }
}