using AutoMapper;
using Core.Transfer;
using Core.Transfer.Mods.Order;
using MediatR;
using Serilog;
using Mod.CameraModule.Base.Queries;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Handlers;

public class GetAllCameraModulesQueryHandler: IRequestHandler<GetAllCameraModulesQuery, ResponseResultWithData<List<CameraModuleModel>>>
{
    private readonly ICameraModuleService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    #region Public Methods

    public GetAllCameraModulesQueryHandler(ILogger logger, IMapper mapper, ICameraModuleService productService)
    {
        _logger = logger;
        _mapper = mapper;
        _productService = productService;
    }
    
    public async Task<ResponseResultWithData<List<CameraModuleModel>>> Handle(GetAllCameraModulesQuery request, CancellationToken cancellationToken)
    {
        var result =  new ResponseResultWithData<List<CameraModuleModel>>{IsSuccess = false};
        try
        {
            var products =  await _productService.GetAllCameraModules();
            var data = products.Select(p => _mapper.Map<CameraModuleModel, CameraModuleModel>(p)).ToList();
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