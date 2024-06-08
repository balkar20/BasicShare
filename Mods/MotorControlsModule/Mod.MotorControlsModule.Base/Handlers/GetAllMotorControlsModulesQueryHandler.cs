using AutoMapper;
using Core.Transfer;
using Core.Transfer.Mods.Order;
using MediatR;
using Serilog;
using Mod.MotorControlsModule.Base.Queries;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Handlers;

public class GetAllMotorControlsModulesQueryHandler: IRequestHandler<GetAllMotorControlsModulesQuery, ResponseResultWithData<List<MotorControlsModuleModel>>>
{
    private readonly IMotorControlsModuleService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    #region Public Methods

    public GetAllMotorControlsModulesQueryHandler(ILogger logger, IMapper mapper, IMotorControlsModuleService productService)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
    }
    
    public async Task<ResponseResultWithData<List<MotorControlsModuleModel>>> Handle(GetAllMotorControlsModulesQuery request, CancellationToken cancellationToken)
    {
        var result =  new ResponseResultWithData<List<MotorControlsModuleModel>>{IsSuccess = false};
        try
        {
            var products =  await _productService.GetAllMotorControlsModules();
            var data = products.Select(p => _mapper.Map<MotorControlsModuleModel, MotorControlsModuleModel>(p)).ToList();
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