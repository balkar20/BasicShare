using AutoMapper;
using MediatR;
using Mod.Product.Base.Models;
using Mod.Product.Base.Queries;
using Mod.Product.Base.Repositories;

namespace Mod.Product.Base.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, List<ProductModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return _productRepository.GetAll().ToList();
    }
}