using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.CameraModule.Root.Configuration;

public class CameraModuleEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public ICameraModuleApiConfiguration CameraModuleApiConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public CameraModuleEnvironmentContext(Func<string, string> getConfigFunc)
    {
        AppConfiguration = new AppConfiguration(getConfigFunc);
        CameraModuleApiConfiguration = new CameraModuleApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}