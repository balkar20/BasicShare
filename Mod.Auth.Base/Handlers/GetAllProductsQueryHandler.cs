using AutoMapper;
using Core.Base.DataBase.Entities;
using MediatR;
using Mod.Auth.Base.Queries;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class GetAllAuthsQueryHandler: IRequestHandler<GetAllAuthsQuery, List<UserModel>>
{
    private readonly IAuthRepository _productRepository;
    private readonly IAuthService _productService;

    public GetAllAuthsQueryHandler(IAuthRepository productRepository, IAuthService productService)
    {
        _productRepository = productRepository;
        _productService = productService;
    }
    
    public async Task<List<UserModel>> Handle(GetAllAuthsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllAuths();
    }
}