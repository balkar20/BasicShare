using AutoMapper;
using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class SavePooperCommandHandler: IRequestHandler<SavePooperCommand, PooperSaveResponseModel>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    public SavePooperCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }
    
    public async Task<PooperSaveResponseModel> Handle(SavePooperCommand request, CancellationToken cancellationToken)
    {
        return await _authService.SavePooper(request.PooperModel);
    }
}