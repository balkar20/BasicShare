using Db.Entities;
using MediatR;
using ModProduct.Queries;
using ModProduct.Repositories;

namespace ModProduct.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository _productRepository
        ;
    public GetAllProductsQueryHandler(IProductRepository productRepository) => _productRepository = productRepository;
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return _productRepository.GetAll().ToList();
    }
}