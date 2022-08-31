using MediatR;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Commands;

public record UpdateShipmentCommand(ShipmentModel Shipment) : IRequest<ShipmentModel>;