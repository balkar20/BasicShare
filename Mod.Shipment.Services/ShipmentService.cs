using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Core.RabbitMqBase.Interfaces;
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
    private readonly  IRabbitMQReader _rabbitMqReader;


    public ShipmentService(
        ILogger logger,
        IOptions<ShipmentApiConfiguration> options,
        IShipmentRepository repository, 
        IRabbitMQReader rabbitMqReader)
    {
        _repository = repository;
        _rabbitMqReader = rabbitMqReader;
        _logger = logger;
        _configuration = options.Value;
        
        rabbitMqReader.ReadMessage();
    }

    public async Task<List<ShipmentModel>> GetAllShipments()
    {
        var Shipments =  await _repository.GetAllMappedToModelAsync<ShipmentEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return Shipments.ToList();
    }
}