using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Options;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;
using Serilog;

namespace Mod.WareHouseProduct.Base.Repositories;

public class WareHouseProductService: IWareHouseProductService
{
    private readonly IWareHouseProductRepository _repository;
    private readonly ILogger _logger;
    private readonly WareHouseProductApiConfiguration _configuration;

    public WareHouseProductService(
        ILogger logger,
        IOptions<WareHouseProductApiConfiguration> options,
        IWareHouseProductRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = options.Value;
    }

    public async Task<List<WareHouseProductModel>> GetAllWareHouseProducts()
    {
        var WareHouseProducts =  await _repository.GetAllMappedToModelAsync<WareHouseProductEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return WareHouseProducts.ToList();
    }
}