using AutoMapper;
using Core.Base.DataBase.Entities;
using MediatR;
using Mod.Auth.Base.Queries;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class GetAllAuthsQueryHandler: IRequestHandler<GetAllAuthsQuery, List<AuthModel>>
{
    //private readonly IAuthRepository _productRepository;
    private readonly IAuthService _authService;

    public GetAllAuthsQueryHandler(IAuthService productService)
    {
        //_productRepository = productRepository;
        _authService = productService;
    }
    
    public async Task<List<AuthModel>> Handle(GetAllAuthsQuery request, CancellationToken cancellationToken)
    {
        //return await _productService.GetAllAuths();
        return new List<AuthModel>();
    }
}