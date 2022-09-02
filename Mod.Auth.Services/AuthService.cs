using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Options;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Serilog;
using Core.Auh.Configuration;
using Core.Auh.Entities;

namespace Mod.Auth.Base.Repositories;

public class AuthService: IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly ILogger _logger;
    private readonly AuthConfiguration _configuration;

    public AuthService(
        ILogger logger,
        IOptions<AuthConfiguration> options,
        IAuthRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = options.Value;
    }

    public async Task<List<UserModel>> GetAllAuths()
    {
        var products =  await _repository.GetAllMappedToModelAsync<UserEntity>(o => o.OrderBy(j => j.UserName), null, null, null);
        return products.ToList();
    }
}