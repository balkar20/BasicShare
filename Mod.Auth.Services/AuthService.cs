using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Options;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Serilog;
using Core.Auh.Configuration;
using Core.Auh.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Mod.Auth.Base.Repositories;

public class AuthService: IAuthService
{
    //private readonly IAuthRepository _repository;
    private readonly ILogger _logger;
    //private SignInManager<UserEntity> _signManager;
    private UserManager<UserEntity> _userManager;
    private readonly AuthConfiguration _configuration;


    public AuthService(
        ILogger logger,
        IOptions<AuthConfiguration> options,
        UserManager<UserEntity> userManager)
    {
        _logger = logger;
        _configuration = options.Value;
        _userManager = userManager;
    }

    //public async Task<List<AuthModel>> GetAllAuths()
    //{
    //    //var products =  await _repository.GetAllMappedToModelAsync<UserEntity>(o => o.OrderBy(j => j.UserName), null, null, null);
    //    //return products.ToList();
    //}

    public async Task<AuthResponseModel> LogIn(AuthModel userForAuthentication)
    {
        var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            return new AuthResponseModel { ErrorMessage = "Invalid Authentication" };
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new AuthResponseModel { IsAuthSuccessful = true, Token = token };
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration.SecurityKey);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    private List<Claim> GetClaims(IdentityUser user)
    {
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Email)
    };

        return claims;
    }
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration.ValidIssuer,
            audience: _configuration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.ExpiryInMinutes)),
            signingCredentials: signingCredentials);

        return tokenOptions;
    }
}