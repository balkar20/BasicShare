using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Options;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;
using Serilog;

namespace Mod.Shipment.Base.Repositories;

public class ShipmentService: IShipmentService
{
    private readonly IShipmentRepository _repository;
    private readonly ILogger _logger;
    private readonly ShipmentApiConfiguration _configuration;

    public ShipmentService(
        ILogger logger,
        IOptions<ShipmentApiConfiguration> options,
        IShipmentRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = options.Value;
    }

    public async Task<List<ShipmentModel>> GetAllShipments()
    {
        var Shipments =  await _repository.GetAllMappedToModelAsync<ShipmentEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return Shipments.ToList();
    }
}