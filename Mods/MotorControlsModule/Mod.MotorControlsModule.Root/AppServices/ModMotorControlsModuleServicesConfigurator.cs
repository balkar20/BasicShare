using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.MotorControlsModule.Base.Repositories;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Services;

namespace Mod.MotorControlsModule.Root.AppServices;

public class ModMotorControlsModuleServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModMotorControlsModuleServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        _services.AddScoped<IMotorControlsModuleRepository, MotorControlsModuleSqlRepository>();
        _services.AddScoped<IMotorControlsModuleService, MotorControlsModuleService>();
    }
}