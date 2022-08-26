// using MediatR;

using MediatR;
using ModProduct.Models;

namespace Mod.Product.Base.Queries;

public record GetAllProductsQuery : IRequest<List<ProductModel>>;