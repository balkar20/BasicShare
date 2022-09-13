using AutoMapper;
using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseModel>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IAuthService authService) => _authService = authService;

    public async Task<AuthResponseModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.LogIn(_mapper.Map<AuthModel>(request.Auth));
    }
}