using MediatR;
using Mod.Auth.Base.Queries;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class GetAllAuthsQueryHandler: IRequestHandler<GetAllAuthsQuery, List<PooperModel>>
{
    private readonly IAuthService _authService;

    public GetAllAuthsQueryHandler(IAuthService productService)
    {
        _authService = productService;
    }
    
    public async Task<List<PooperModel>> Handle(GetAllAuthsQuery request, CancellationToken cancellationToken)
    {
        var result = await _authService.GetAllAuths();
        return result;
    }
}