using AutoMapper;
using Core.Transfer;
using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Serilog;

namespace Mod.Auth.Base.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseResultWithData<RegisterResponseModel>>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public RegisterCommandHandler(IAuthService authService, IMapper mapper, ILogger logger)
    {
        _authService = authService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ResponseResultWithData<RegisterResponseModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var responseModel = new ResponseResultWithData<RegisterResponseModel>()
        {
            IsSuccess = false
        };
        try
        {
            var result =  await _authService.RegisterUser(_mapper.Map<RegisterModel>(request.RegisterViewModel));
            responseModel.Data = result;
            responseModel.IsSuccess = true;
        }
        catch (Exception e)
        {
            _logger.Error($"Register error for user : {request.RegisterViewModel.UserName}");
        }

        return responseModel;
    }
}