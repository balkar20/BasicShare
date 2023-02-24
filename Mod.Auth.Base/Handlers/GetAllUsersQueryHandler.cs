using Core.Transfer;
using MediatR;
using Mod.Auth.Base.Queries;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class GetAllAuthsQueryHandler: IRequestHandler<GetAllUsersQuery, ResponseResultWithData<List<PooperModel>>>
{
    private readonly IAuthService _authService;

    public GetAllAuthsQueryHandler(IAuthService productService)
    {
        _authService = productService;
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
        }
        catch(Exception ex)
        {
            response.Errors.Add(ex.Message);
        }
        
        return response;
    }
}