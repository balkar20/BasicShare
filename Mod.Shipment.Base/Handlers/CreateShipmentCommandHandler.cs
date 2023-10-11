using Infrastructure.Interfaces;
using MediatR;
using Mod.Shipment.Base.Commands;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Handlers;

public class CreateShipmentCommandHandler: IRequestHandler<CreateShipmentCommand, ShipmentModel>
{
    private readonly IShipmentRepository _shipmentRepository;
    private readonly IMessageBusService _messageBusService;
    public CreateShipmentCommandHandler(IShipmentRepository ShipmentRepository, IMessageBusService messageBusService)
    {
        _shipmentRepository = ShipmentRepository;
        _messageBusService = messageBusService;
    }

    public async Task<ShipmentModel> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        var shipment =  await _shipmentRepository.AddAsync(request.Shipment);
        await _messageBusService.PublishMessage(request.Shipment);
        return shipment;
    }
}