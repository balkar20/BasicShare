using Infrastructure.Interfaces;
using MediatR;
using Mod.Shipment.Base.Commands;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Handlers;

public class CreateShipmentCommandHandler: IRequestHandler<CreateShipmentCommand, ShipmentModel>
{
    private readonly IShipmentRepository _ShipmentRepository;
    private readonly IRabitMQProducer _rabbitMqProducer;
    public CreateShipmentCommandHandler(IShipmentRepository ShipmentRepository, IRabitMQProducer rabbitMqProducer)
    {
        _ShipmentRepository = ShipmentRepository;
        _rabbitMqProducer = rabbitMqProducer;
    }

    public async Task<ShipmentModel> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        var shipment =  await _ShipmentRepository.AddAsync(request.Shipment);
        _rabbitMqProducer.SendMessage(request.Shipment);
        return shipment;
    }
}