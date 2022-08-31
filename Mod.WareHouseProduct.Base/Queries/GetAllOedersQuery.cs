using MediatR;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Queries;

public record GetAllWareHouseProductsQuery : IRequest<List<WareHouseProductModel>>;