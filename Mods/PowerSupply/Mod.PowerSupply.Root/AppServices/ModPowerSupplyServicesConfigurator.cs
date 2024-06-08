using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.PowerSupply.Base.Repositories;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Services;

namespace Mod.PowerSupply.Root.AppServices;

public class ModPowerSupplyServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModPowerSupplyServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        _services.AddScoped<IPowerSupplyRepository, PowerSupplySqlRepository>();
        _services.AddScoped<IPowerSupplyService, PowerSupplyService>();
    }
}