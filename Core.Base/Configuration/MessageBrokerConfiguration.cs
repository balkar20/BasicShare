namespace Core.Base.Configuration;

public class MessageBrokerConfiguration
{
    public const string HostConfiguration = "MessageBrokerConfiguration";
    public string QueName { get; set; }
    public string HostName { get; set; }
}