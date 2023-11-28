namespace Core.Base.Configuration;

public class ConfigurationContext
{
    public AppConfiguration AppConfiguration { get; set; }
    
    public ProductApiConfiguration ProductApiConfiguration { get; set; }

    public static void SetUpConfigurationContext(ConfigurationContext configurationContext, 
        AppConfiguration appConfiguration, ProductApiConfiguration productApiConfiguration)
    {
        configurationContext.AppConfiguration = appConfiguration;
        configurationContext.ProductApiConfiguration = productApiConfiguration;
    }
}