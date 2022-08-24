using AutoMapper;
using Core.Base.DataBase.Entities;
using MediatR;
using Mod.Product.Base.Queries;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, List<ProductModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IProductService productService)
    {
        _productRepository = productRepository;
        _productService = productService;
    }
    
    public async Task<List<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllProducts();
    }
}