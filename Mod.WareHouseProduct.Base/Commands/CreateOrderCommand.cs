using MediatR;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Commands;

public record CreateWareHouseProductCommand(WareHouseProductModel WareHouseProduct) : IRequest<WareHouseProductModel>;