using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;

namespace Mod.MotorControlsModule.Root.Configuration;

public class MotorControlsModuleEnvironmentContext
{
    public AppConfiguration AppConfiguration { get; set; }
    public IMotorControlsModuleApiConfiguration MotorControlsModuleApiConfiguration { get; set; }
    public IMessageBrokerConfiguration MessageBrokerConfiguration { get; set; }

    public MotorControlsModuleEnvironmentContext(Func<string, string> getConfigFunc)
    {
        AppConfiguration = new AppConfiguration(getConfigFunc);
        MotorControlsModuleApiConfiguration = new MotorControlsModuleApiConfiguration(getConfigFunc);
        MessageBrokerConfiguration = new MessageBrokerConfiguration(getConfigFunc);
    }

}