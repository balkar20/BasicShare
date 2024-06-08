using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.CameraModule.Base.Repositories;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Services;

namespace Mod.CameraModule.Root.AppServices;

public class ModCameraModuleServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModCameraModuleServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        _services.AddScoped<ICameraModuleRepository, CameraModuleSqlRepository>();
        _services.AddScoped<ICameraModuleService, CameraModuleService>();
    }
}