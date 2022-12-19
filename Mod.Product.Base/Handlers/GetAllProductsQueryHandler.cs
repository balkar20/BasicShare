using AutoMapper;
using Core.Base.DataBase.Entities;
using Core.Base.Output;
using MediatR;
using Mod.Product.Base.Queries;
using Mod.Product.Base.ViewModels;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, OutputViewModelWithData<List<ProductViewModel>>>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IProductService productService, IMapper mapper)
    {
        _productRepository = productRepository;
        _productService = productService;
        _mapper = mapper;
    }
    
    public async Task<OutputViewModelWithData<List<ProductViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products =  await _productService.GetAllProducts();
            var data = products.Select(p => _mapper.Map<ProductModel, ProductViewModel>(p)).ToList();
            return  new OutputViewModelWithData<List<ProductViewModel>>(true, null, data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OutputViewModelWithData<List<ProductViewModel>>(false, e.Message, null);
        }
    }
}