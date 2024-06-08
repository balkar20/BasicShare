using AutoMapper;
using Core.Transfer;
using Core.Transfer.Mods.Order;
using MediatR;
using Serilog;
using Mod.PowerSupply.Base.Queries;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Handlers;

public class GetAllPowerSupplysQueryHandler: IRequestHandler<GetAllPowerSupplysQuery, ResponseResultWithData<List<PowerSupplyModel>>>
{
    private readonly IPowerSupplyService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    #region Public Methods

    public GetAllPowerSupplysQueryHandler(ILogger logger, IMapper mapper, IPowerSupplyService productService)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
    }
    
    public async Task<ResponseResultWithData<List<PowerSupplyModel>>> Handle(GetAllPowerSupplysQuery request, CancellationToken cancellationToken)
    {
        var result =  new ResponseResultWithData<List<PowerSupplyModel>>{IsSuccess = false};
        try
        {
            var products =  await _productService.GetAllPowerSupplys();
            var data = products.Select(p => _mapper.Map<PowerSupplyModel, PowerSupplyModel>(p)).ToList();
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