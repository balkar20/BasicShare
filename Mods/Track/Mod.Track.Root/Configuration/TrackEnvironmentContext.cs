using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.Track.Root.Configuration;

public class TrackEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public ITrackApiConfiguration TrackApiConfiguration { get; set; }
    public IDocumentDataConfiguration DocumentDataConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public TrackEnvironmentContext(Func<string, string?> getConfigFunc)
    {
        DocumentDataConfiguration = new DocumentDataConfiguration(getConfigFunc);
        AppConfiguration = new AppConfiguration(getConfigFunc);
        TrackApiConfiguration = new TrackApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}