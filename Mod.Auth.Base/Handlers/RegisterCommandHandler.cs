using AutoMapper;
using Core.Transfer;
using MediatR;
using Microsoft.Extensions.Localization;
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
    private readonly IStringLocalizer<RegisterCommandHandler> _stringLocalizer;

    public RegisterCommandHandler(IAuthService authService, IMapper mapper, ILogger logger, IStringLocalizer<RegisterCommandHandler> stringLocalizer)
    {
        _authService = authService;
        _mapper = mapper;
        _logger = logger;
        this._stringLocalizer = stringLocalizer;
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
            responseModel.Message = _stringLocalizer.GetString("UserCreated", request.RegisterViewModel.UserName);
        }
        catch (Exception e)
        {
            _logger.Error($"Register error for user : {request.RegisterViewModel.UserName}");
        }

        return responseModel;
    }
}