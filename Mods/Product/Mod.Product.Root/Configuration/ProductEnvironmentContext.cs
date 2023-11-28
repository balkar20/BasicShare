using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.Product.Root.Configuration;

public class ProductEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public IProductApiConfiguration ProductApiConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public ProductEnvironmentContext(Func<string, string> getConfigFunc)
    {
        AppConfiguration = new AppConfiguration(getConfigFunc);
        ProductApiConfiguration = new ProductApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}