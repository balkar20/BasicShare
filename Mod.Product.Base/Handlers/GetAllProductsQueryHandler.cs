using AutoMapper;
using Core.Base.Output;
using Core.Transfer.Mods.Order;
using Infrastructure.Interfaces;
using MediatR;
using Serilog;
using Mod.Product.Base.Queries;
using Mod.Product.Base.ViewModels;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Base.Handlers;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, OutputViewModelWithData<List<ProductViewModel>>>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IRabbitMQReader _rabbitMqReader;

    #region Public Methods

    public GetAllProductsQueryHandler(ILogger logger, IMapper mapper, IProductService productService, IRabbitMQReader rabbitMqReader)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
        rabbitMqReader.ListenEventsFromQue<OrderModel>(HandleOrder);
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

    #endregion Public Methods

    #region Private Methods

    private void HandleOrder(OrderModel orderModel)
    {
        if (orderModel == null)
        {
            _logger.Error("orderModel = null");
            return;
        }
        _logger.Information(orderModel.Description);
    }

    #endregion Private Methods
    
}