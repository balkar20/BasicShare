using AutoMapper;
using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Core.Transfer;

namespace Mod.Auth.Base.Handlers;

public class SavePooperCommandHandler: IRequestHandler<SaveUserCommand, BaseResponseResult>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    public SavePooperCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }
    
    public async Task<BaseResponseResult> Handle(SaveUserCommand request, CancellationToken cancellationToken)
    {
        return await _authService.SavePooper(request.UserModel);
    }
}