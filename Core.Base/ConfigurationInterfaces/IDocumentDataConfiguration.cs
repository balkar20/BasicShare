namespace Core.Base.ConfigurationInterfaces;

public interface IDocumentDataConfiguration
{
    string ConnectionString  { get; }
    string DatabaseName  { get;  }
    string DataCollectionName { get; }
}