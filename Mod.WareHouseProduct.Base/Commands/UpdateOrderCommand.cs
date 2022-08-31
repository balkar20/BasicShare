using MediatR;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Commands;

public record UpdateWareHouseProductCommand(WareHouseProductModel WareHouseProduct) : IRequest<WareHouseProductModel>;