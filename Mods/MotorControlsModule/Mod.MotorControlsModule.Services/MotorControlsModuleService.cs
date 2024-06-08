using Core.Base.ConfigurationInterfaces;
using Core.Base.DataBase.Entities;
using Serilog;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Repositories;

public class MotorControlsModuleService: IMotorControlsModuleService
{
    private readonly IMotorControlsModuleRepository _repository;
    private readonly ILogger _logger;
    private readonly IMotorControlsModuleApiConfiguration _configuration;

    public MotorControlsModuleService(
        ILogger logger,
        IMotorControlsModuleApiConfiguration configuration,
        IMotorControlsModuleRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<MotorControlsModuleModel>> GetAllMotorControlsModules()
    {
        var products =  await _repository.GetAllMappedToModelAsync<MotorControlsModuleEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }

    public async Task<MotorControlsModuleModel> UpdateMotorControlsModule(MotorControlsModuleModel product)
    {
        var productModel = await _repository.UpdateAsync(product);
        return productModel;
    }

    public async Task<MotorControlsModuleModel> CreateAsync(MotorControlsModuleModel requestMotorControlsModule)
    {
        var productModel = await _repository.AddAsync(requestMotorControlsModule);
        return productModel;
    }
}