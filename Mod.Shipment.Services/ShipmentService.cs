using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
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
    private readonly  IMessageBusReader _messageBusReader;


    public ShipmentService(
        ILogger logger,
        IOptions<ShipmentApiConfiguration> options,
        IShipmentRepository repository, 
        IMessageBusReader messageBusReader)
    {
        _repository = repository;
        _messageBusReader = messageBusReader;
        _logger = logger;
        _configuration = options.Value;
        
        messageBusReader.ListenEventsFromQue<OrderMessage>(HandleOrder);
    }

    #region Public Methods

    public async Task<List<ShipmentModel>> GetAllShipments()
    {
        _logger.Information("kjhjkhjkhkjhkjh");
        var Shipments =
            await _repository.GetAllMappedToModelAsync<ShipmentEntity>(o => o.OrderBy(j => j.Description), null, null,
                null);
        return Shipments.ToList();
    }
    
    #endregion

    #region Private Methods

    public void HandleOrder(OrderMessage orderMessage)
    {
        if (orderMessage != null) 
            _logger.Debug($"ShipmentService got message: {orderMessage.Description}");
    }

    #endregion
    
    
    
}