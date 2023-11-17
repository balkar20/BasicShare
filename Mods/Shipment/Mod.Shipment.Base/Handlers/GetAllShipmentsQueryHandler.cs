using AutoMapper;
using Core.Transfer;
using Core.Transfer.Mods.Order;
using MediatR;
using Serilog;
using Mod.Shipment.Base.Queries;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Handlers;

public class GetAllShipmentsQueryHandler: IRequestHandler<GetAllShipmentsQuery, ResponseResultWithData<List<ShipmentModel>>>
{
    private readonly IShipmentService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    #region Public Methods

    public GetAllShipmentsQueryHandler(ILogger logger, IMapper mapper, IShipmentService productService)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
    }
    
    public async Task<ResponseResultWithData<List<ShipmentModel>>> Handle(GetAllShipmentsQuery request, CancellationToken cancellationToken)
    {
        var result =  new ResponseResultWithData<List<ShipmentModel>>{IsSuccess = false};
        try
        {
            var products =  await _productService.GetAllShipments();
            var data = products.Select(p => _mapper.Map<ShipmentModel, ShipmentModel>(p)).ToList();
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