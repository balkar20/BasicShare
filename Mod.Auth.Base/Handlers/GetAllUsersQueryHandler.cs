using Core.Transfer;
using MediatR;
using Microsoft.Extensions.Localization;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Resources;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Serilog;

namespace Mod.Auth.Base.Handlers;

public class GetAllAuthsQueryHandler: IRequestHandler<GetAllUsersQuery, ResponseResultWithData<List<UserModel>>>
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
    
    public async Task<ResponseResultWithData<List<UserModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var response = new ResponseResultWithData<List<UserModel>>()
        {
            IsSuccess = false
        };
        try
        {
            _logger.Information("PagingModel: {SortDirection}", request.DataListPagingModel.SortDirection);

            var result = await _authService.GetPaginatedUsers(request.DataListPagingModel);
            response.Data = result.UserModels;
            response.Count = result.TotalDataCount;
            response.IsSuccess = true;
            response.Message = _stringLocalizer.GetString(ResourceKeysSuccessConstants.LOadSuccess, result.DataCount);
            response.DataLabels = result.Claims;
            _logger.Information("Successfully returned list of users, count: {ResultCount}", result.DataCount);
        }
        catch(Exception ex)
        {
            _logger.Error(ex, ex.Message);
            response.Errors.Add(ex.Message);
        }
        
        return response;
    }
}