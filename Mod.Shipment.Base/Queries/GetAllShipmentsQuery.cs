using MediatR;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Queries;

public record GetAllShipmentsQuery : IRequest<List<ShipmentModel>>;