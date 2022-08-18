using MediatR;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Queries;

public record GetAllProductsQuery : IRequest<List<ProductModel>>;