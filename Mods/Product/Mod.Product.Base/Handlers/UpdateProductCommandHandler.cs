using Core.Transfer;
using MediatR;
using Mod.Product.Base.Commands;
using Mod.Product.Interfaces;
using Mod.Product.Models;
using Serilog;

namespace Mod.Product.Base.Handlers;

public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, BaseResponseResult>
{
    private readonly IProductService _productService;
    private readonly ILogger _logger;
    
    public UpdateProductCommandHandler(IProductService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<BaseResponseResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        BaseResponseResult responseResult = new BaseResponseResult() { IsSuccess = false };

        try
        {
            var serviceResult = await _productService.UpdateProduct(request.Product);
            if (serviceResult != null)
            {
                responseResult.IsSuccess = true;
                responseResult.Message = $"Product : {serviceResult.Name} was updated";
            }
            
        }
        catch(Exception e)
        {responseResult.Errors.Add($"Error: {e.Message}");
            if (e.Message != null) _logger.Error(e.Message);
        }

        return responseResult;
    }
}