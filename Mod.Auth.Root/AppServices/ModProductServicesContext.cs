using Infrastructure.Interfaces;
using Mod.Auth.Interfaces;

namespace Mod.Auth.Root.AppServices;

public class ModAuthServicesContext
{
    public IRabbitMqProducer RabbitMqProducer { get; set; }
    
    // public IAuthRepository AuthRepository { get; set; }
    
    public IAuthService AuthService { get; set; }

    public ModAuthServicesContext()
    {
        
    }
}