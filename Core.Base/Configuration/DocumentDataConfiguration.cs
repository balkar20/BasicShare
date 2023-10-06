using Core.Base.ConfigurationInterfaces;

namespace Core.Base.Configuration;

public class DocumentDataConfiguration: BaseConfiguration, IDocumentDataConfiguration
{
    public DocumentDataConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }
    
    public string ConnectionString { get => GetConfigFuncString("RABBIT_HOST_NAME"); }
    public string DatabaseName { get => GetConfigFuncString("RABBIT_HOST_NAME"); }
    public string DataCollectionName { get => GetConfigFuncString("RABBIT_HOST_NAME"); }
}