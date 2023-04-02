using Core.Transfer;
using MediatR;
using Microsoft.Extensions.Localization;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Resources;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Serilog;

namespace Mod.Auth.Base.Handlers;

public class GetAllAuthsQueryHandler: IRequestHandler<GetAllUsersQuery, ResponseResultWithData<List<PooperModel>>>
{
    private readonly IAuthService _authService;
    private readonly ILogger _logger;
    private readonly IStringLocalizer<GetAllAuthsQueryHandler> _stringLocalizer;

    public GetAllAuthsQueryHandler(IAuthService productService, ILogger logger, IStringLocalizer<GetAllAuthsQueryHandler> stringLocalizer)
    {
        _authService = productService;
        _logger = logger;
        _stringLocalizer = stringLocalizer;
    }
    
    public async Task<ResponseResultWithData<List<PooperModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var response = new ResponseResultWithData<List<PooperModel>>()
        {
            IsSuccess = false
        };
        try
        {
            var result = await _authService.GetAllPoopers();
            response.Data = result;
            response.IsSuccess = true;
            response.Message = _stringLocalizer.GetString(ResourceKeysSuccessConstants.LOadSuccess, result.Count);
            _logger.Information("Successfully returned list of products, count: {ResultCount}", result.Count);
        }
        catch(Exception ex)
        {
            _logger.Error(ex, ex.Message);
            response.Errors.Add(ex.Message);
        }
        
        return response;
    }
}