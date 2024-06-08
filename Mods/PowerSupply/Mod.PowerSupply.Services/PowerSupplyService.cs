using Core.Base.ConfigurationInterfaces;
using Core.Base.DataBase.Entities;
using Serilog;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Repositories;

public class PowerSupplyService: IPowerSupplyService
{
    private readonly IPowerSupplyRepository _repository;
    private readonly ILogger _logger;
    private readonly IPowerSupplyApiConfiguration _configuration;

    public PowerSupplyService(
        ILogger logger,
        IPowerSupplyApiConfiguration configuration,
        IPowerSupplyRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<PowerSupplyModel>> GetAllPowerSupplys()
    {
        var products =  await _repository.GetAllMappedToModelAsync<PowerSupplyEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }

    public async Task<PowerSupplyModel> UpdatePowerSupply(PowerSupplyModel product)
    {
        var productModel = await _repository.UpdateAsync(product);
        return productModel;
    }

    public async Task<PowerSupplyModel> CreateAsync(PowerSupplyModel requestPowerSupply)
    {
        var productModel = await _repository.AddAsync(requestPowerSupply);
        return productModel;
    }
}