using AutoMapper;
using Core.Base.DataBase.Entities;
using Core.Base.Output;
using Core.Base.Utilities;
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
    public GetAllProductsQueryHandler(IProductService productService, IMapper mapper, ILogger logger)
    {
        _productService = productService;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<OutputViewModelWithData<List<ProductViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.Information("GetAllProductsHandler");
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