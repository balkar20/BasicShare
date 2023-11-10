using AutoMapper;
using Core.Transfer;
using Core.Transfer.Mods.Order;
using MediatR;
using Serilog;
using Mod.Product.Base.Queries;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Base.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, ResponseResultWithData<List<ProductModel>>>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    #region Public Methods

    public GetAllProductsQueryHandler(ILogger logger, IMapper mapper, IProductService productService)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
    }
    
    public async Task<ResponseResultWithData<List<ProductModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result =  new ResponseResultWithData<List<ProductModel>>{IsSuccess = false};
        try
        {
            var products =  await _productService.GetAllProducts();
            var data = products.Select(p => _mapper.Map<ProductModel, ProductModel>(p)).ToList();
            if (data.Any())
            {
                _logger.Information("Some products exists in DataBase");
                result.Count = data.Count;
                result.Data = data;
                result.IsSuccess = true;
            }
            
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            ;
            result.Message = e.Message;
        }

        return result;
    }

    #endregion Public Methods

    #region Private Methods

    private void HandleOrder(OrderModel orderModel)
    {
        if (orderModel == null)
        {
            _logger.Error("orderModel = null");
            return;
        }
        _logger.Information($"Message{orderModel.Description}");
    }

    #endregion Private Methods
    
}