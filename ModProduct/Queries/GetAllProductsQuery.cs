using Db.Entities;
using MediatR;
namespace ModProduct.Queries;

public class GetAllProductsQuery : IRequest<List<Product>>
{
    
}