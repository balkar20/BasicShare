using Core.Base.ConfigurationInterfaces;

namespace Core.Base.Configuration;

public class DocumentDataConfiguration: BaseConfiguration, IDocumentDataConfiguration
{
    public DocumentDataConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }
    
    public string ConnectionString { get => GetConfigFuncString("EVENT_CONNECTION"); }
    public string DatabaseName { get => GetConfigFuncString("EVENT_DATA_BASE"); }
    public string DataCollectionName { get => GetConfigFuncString("EVENT_COLLECTION"); }
}