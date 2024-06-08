using Core.Transfer;
using MediatR;
using Mod.PowerSupply.Base.Commands;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Models;
using Serilog;

namespace Mod.PowerSupply.Base.Handlers;

public class UpdatePowerSupplyCommandHandler: IRequestHandler<UpdatePowerSupplyCommand, BaseResponseResult>
{
    private readonly IPowerSupplyService _productService;
    private readonly ILogger _logger;
    
    public UpdatePowerSupplyCommandHandler(IPowerSupplyService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<BaseResponseResult> Handle(UpdatePowerSupplyCommand request, CancellationToken cancellationToken)
    {
        BaseResponseResult responseResult = new BaseResponseResult() { IsSuccess = false };

        try
        {
            var serviceResult = await _productService.UpdatePowerSupply(request.PowerSupply);
            if (serviceResult != null)
            {
                responseResult.IsSuccess = true;
                responseResult.Message = $"PowerSupply : {serviceResult.Name} was updated";
            }
            
        }
        catch(Exception e)
        {responseResult.Errors.Add($"Error: {e.Message}");
            if (e.Message != null) _logger.Error(e.Message);
        }

        return responseResult;
    }
}