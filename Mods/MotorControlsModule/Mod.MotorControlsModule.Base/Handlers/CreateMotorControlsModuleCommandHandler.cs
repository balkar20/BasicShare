using Core.Transfer;
using MediatR;
using Mod.MotorControlsModule.Base.Commands;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Models;
using Serilog;

namespace Mod.MotorControlsModule.Base.Handlers;

public class CreateMotorControlsModuleCommandHandler: IRequestHandler<CreateMotorControlsModuleCommand, BaseResponseResult>
{
    private readonly IMotorControlsModuleService _productService;
    private readonly ILogger _logger;

    public CreateMotorControlsModuleCommandHandler(IMotorControlsModuleService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<BaseResponseResult> Handle(CreateMotorControlsModuleCommand request, CancellationToken cancellationToken)
    {
        BaseResponseResult responseResult = new BaseResponseResult() { IsSuccess = false };

        try
        {
            var serviceResult = await _productService.CreateAsync(request.MotorControlsModule);
            if (serviceResult != null)
            {
                responseResult.IsSuccess = true;
                responseResult.Message = $"MotorControlsModule : {serviceResult.Name} was created";
            }
            
        }
        catch(Exception e)
        {responseResult.Errors.Add($"Error: {e.Message}");
            if (e.Message != null) _logger.Error(e.Message);
        }

        return responseResult;
    }
}