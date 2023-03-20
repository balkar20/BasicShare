using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Interfaces;
using Mod.Auth.Services;
using Mod.Order.Base.Repositories;
using Mod.Order.Interfaces;

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
        _services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();


        _services.AddScoped<IOrderRepository, OrderRepository>();
        _services.AddScoped<IAuthService, AuthService>();
    }
}