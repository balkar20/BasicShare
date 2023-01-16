using MediatR;
using Mod.Shipment.Base.Queries;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Handlers;

public class GetAllShipmentsQueryHandler: IRequestHandler<GetAllShipmentsQuery, List<ShipmentModel>>
{
    private readonly IShipmentRepository _ShipmentRepository;
    private readonly IShipmentService _ShipmentService;

    public GetAllShipmentsQueryHandler(IShipmentRepository ShipmentRepository, IShipmentService ShipmentService)
    {
        _ShipmentRepository = ShipmentRepository;
        _ShipmentService = ShipmentService;
    }
    
    public async Task<List<ShipmentModel>> Handle(GetAllShipmentsQuery request, CancellationToken cancellationToken)
    {
        return await _ShipmentService.GetAllShipments();
    }
}