using Core.Transfer;
using MediatR;
using Mod.Shipment.Base.Commands;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;
using Serilog;

namespace Mod.Shipment.Base.Handlers;

public class CreateShipmentCommandHandler: IRequestHandler<CreateShipmentCommand, BaseResponseResult>
{
    private readonly IShipmentService _productService;
    private readonly ILogger _logger;

    public CreateShipmentCommandHandler(IShipmentService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<BaseResponseResult> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        BaseResponseResult responseResult = new BaseResponseResult() { IsSuccess = false };

        try
        {
            var serviceResult = await _productService.CreateAsync(request.Shipment);
            if (serviceResult != null)
            {
                responseResult.IsSuccess = true;
                responseResult.Message = $"Shipment : {serviceResult.Name} was created";
            }
            
        }
        catch(Exception e)
        {responseResult.Errors.Add($"Error: {e.Message}");
            if (e.Message != null) _logger.Error(e.Message);
        }

        return responseResult;
    }
}