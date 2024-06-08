using Core.Transfer;
using MediatR;
using Mod.CameraModule.Base.Commands;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Models;
using Serilog;

namespace Mod.CameraModule.Base.Handlers;

public class UpdateCameraModuleCommandHandler: IRequestHandler<UpdateCameraModuleCommand, BaseResponseResult>
{
    private readonly ICameraModuleService _productService;
    private readonly ILogger _logger;
    
    public UpdateCameraModuleCommandHandler(ICameraModuleService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<BaseResponseResult> Handle(UpdateCameraModuleCommand request, CancellationToken cancellationToken)
    {
        BaseResponseResult responseResult = new BaseResponseResult() { IsSuccess = false };

        try
        {
            var serviceResult = await _productService.UpdateCameraModule(request.CameraModule);
            if (serviceResult != null)
            {
                responseResult.IsSuccess = true;
                responseResult.Message = $"CameraModule : {serviceResult.Name} was updated";
            }
            
        }
        catch(Exception e)
        {responseResult.Errors.Add($"Error: {e.Message}");
            if (e.Message != null) _logger.Error(e.Message);
        }

        return responseResult;
    }
}