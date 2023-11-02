using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Interfaces;

namespace Mod.Auth.Root.AppServices;

public class ModAuthServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModAuthServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        // _services.AddSingleton<IMessageBusService, MessageBusService>();
        // _services.AddScoped<IOrderRepository, OrderRepository>();
        
        _services.AddScoped<IAuthService, AuthService>();
    }
}