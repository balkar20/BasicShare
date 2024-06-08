using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.PowerSupply.Root.Configuration;

public class PowerSupplyEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public IPowerSupplyApiConfiguration PowerSupplyApiConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public PowerSupplyEnvironmentContext(Func<string, string> getConfigFunc)
    {
        AppConfiguration = new AppConfiguration(getConfigFunc);
        PowerSupplyApiConfiguration = new PowerSupplyApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}