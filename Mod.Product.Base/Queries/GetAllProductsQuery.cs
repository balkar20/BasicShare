using MediatR;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Queries;

public class GetAllProductsQuery : IRequest<List<ProductModel>>
{
}