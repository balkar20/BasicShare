using MediatR;
using Mod.Shipment.Base.Commands;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Handlers;

public class UpdateShipmentCommandHandler: IRequestHandler<UpdateShipmentCommand, ShipmentModel>
{
    private readonly IShipmentRepository _ShipmentRepository;
    
    public UpdateShipmentCommandHandler(IShipmentRepository ShipmentRepository) => _ShipmentRepository = ShipmentRepository;

    public async Task<ShipmentModel> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
    {
        return await _ShipmentRepository.UpdateAsync(request.Shipment);
    }
}