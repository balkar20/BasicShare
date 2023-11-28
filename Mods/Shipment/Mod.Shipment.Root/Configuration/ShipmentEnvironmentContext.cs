using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.Shipment.Root.Configuration;

public class ShipmentEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public IShipmentApiConfiguration ShipmentApiConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public ShipmentEnvironmentContext(Func<string, string> getConfigFunc)
    {
        AppConfiguration = new AppConfiguration(getConfigFunc);
        ShipmentApiConfiguration = new ShipmentApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}