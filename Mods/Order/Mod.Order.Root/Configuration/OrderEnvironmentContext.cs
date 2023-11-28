using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.Order.Root.Configuration;

public class OrderEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public IOrderApiConfiguration OrderApiConfiguration { get; set; }
    public IDocumentDataConfiguration DocumentDataConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public OrderEnvironmentContext(Func<string, string?> getConfigFunc)
    {
        DocumentDataConfiguration = new DocumentDataConfiguration(getConfigFunc);
        AppConfiguration = new AppConfiguration(getConfigFunc);
        OrderApiConfiguration = new OrderApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}