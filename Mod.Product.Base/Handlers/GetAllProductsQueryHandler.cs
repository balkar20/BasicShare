using AutoMapper;
using Core.Base.Output;
using MediatR;
using Serilog;
using Mod.Product.Base.Queries;
using Mod.Product.Base.ViewModels;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, OutputViewModelWithData<List<ProductViewModel>>>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllProductsQueryHandler(ILogger logger, IMapper mapper, IProductService productService)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
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
            _logger.Error(e.Message);
            return new OutputViewModelWithData<List<ProductViewModel>>(false, e.Message, null);
        }
    }
}