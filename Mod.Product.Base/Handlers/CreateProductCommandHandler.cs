using Core.Transfer;
using MediatR;
using Mod.Product.Base.Commands;
using Mod.Product.Interfaces;
using Mod.Product.Models;
using Serilog;

namespace Mod.Product.Base.Handlers;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, BaseResponseResult>
{
    private readonly IProductService _productService;
    private readonly ILogger _logger;

    public CreateProductCommandHandler(IProductService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<BaseResponseResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        BaseResponseResult responseResult = new BaseResponseResult() { IsSuccess = false };

        try
        {
            var serviceResult = await _productService.CreateAsync(request.Product);
            if (serviceResult != null)
            {
                responseResult.IsSuccess = true;
                responseResult.Message = $"Product : {serviceResult.Name} was created";
            }
            
        }
        catch(Exception e)
        {responseResult.Errors.Add($"Error: {e.Message}");
            if (e.Message != null) _logger.Error(e.Message);
        }

        return responseResult;
    }
}