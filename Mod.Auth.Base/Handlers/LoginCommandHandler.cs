using AutoMapper;
using Core.Transfer;
using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseResultWithData<LoginResponseModel>>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<ResponseResultWithData<LoginResponseModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseResultWithData<LoginResponseModel>()
        {
            IsSuccess = false
        };
        try
        {
            var result = await _authService.LogIn(_mapper.Map<LoginModel>(request.Auth));
            response.Data = result;
            response.IsSuccess = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }
}