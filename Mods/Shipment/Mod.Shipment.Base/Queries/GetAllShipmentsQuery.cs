// using MediatR;

using Core.Base.Output;
using Core.Transfer;
using MediatR;
using Mod.Shipment.Base.ViewModels;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Queries;

public record GetAllShipmentsQuery : IRequest<ResponseResultWithData<List<ShipmentModel>>>;