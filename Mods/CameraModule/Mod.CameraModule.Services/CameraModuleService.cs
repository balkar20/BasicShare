using Core.Base.ConfigurationInterfaces;
using Core.Base.DataBase.Entities;
using Serilog;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Repositories;

public class CameraModuleService: ICameraModuleService
{
    private readonly ICameraModuleRepository _repository;
    private readonly ILogger _logger;
    private readonly ICameraModuleApiConfiguration _configuration;

    public CameraModuleService(
        ILogger logger,
        ICameraModuleApiConfiguration configuration,
        ICameraModuleRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<CameraModuleModel>> GetAllCameraModules()
    {
        var products =  await _repository.GetAllMappedToModelAsync<CameraModuleEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }

    public async Task<CameraModuleModel> UpdateCameraModule(CameraModuleModel product)
    {
        var productModel = await _repository.UpdateAsync(product);
        return productModel;
    }

    public async Task<CameraModuleModel> CreateAsync(CameraModuleModel requestCameraModule)
    {
        var productModel = await _repository.AddAsync(requestCameraModule);
        return productModel;
    }
}