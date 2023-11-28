using Core.Base.ConfigurationInterfaces;
using Core.Base.DataBase.Entities;
using Serilog;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Repositories;

public class ShipmentService: IShipmentService
{
    private readonly IShipmentRepository _repository;
    private readonly ILogger _logger;
    private readonly IShipmentApiConfiguration _configuration;

    public ShipmentService(
        ILogger logger,
        IShipmentApiConfiguration configuration,
        IShipmentRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<ShipmentModel>> GetAllShipments()
    {
        var products =  await _repository.GetAllMappedToModelAsync<ShipmentEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }

    public async Task<ShipmentModel> UpdateShipment(ShipmentModel product)
    {
        var productModel = await _repository.UpdateAsync(product);
        return productModel;
    }

    public async Task<ShipmentModel> CreateAsync(ShipmentModel requestShipment)
    {
        var productModel = await _repository.AddAsync(requestShipment);
        return productModel;
    }
}