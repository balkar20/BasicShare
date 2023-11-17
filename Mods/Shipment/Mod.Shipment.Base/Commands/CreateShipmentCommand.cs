using Core.Transfer;
using MediatR;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Commands;

public record CreateShipmentCommand(ShipmentModel Shipment) : IRequest<BaseResponseResult>;