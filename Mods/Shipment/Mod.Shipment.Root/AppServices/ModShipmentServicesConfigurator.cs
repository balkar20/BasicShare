using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Shipment.Base.Repositories;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Services;

namespace Mod.Shipment.Root.AppServices;

public class ModShipmentServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModShipmentServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        _services.AddScoped<IShipmentRepository, ShipmentSqlRepository>();
        _services.AddScoped<IShipmentService, ShipmentService>();
    }
}