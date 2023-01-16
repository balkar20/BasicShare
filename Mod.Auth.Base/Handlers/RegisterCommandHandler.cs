using AutoMapper;
using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponseModel>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<RegisterResponseModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await _authService.RegisterUser(_mapper.Map<RegisterModel>(request.RegisterViewModel));
    }
}