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
        var claims = await GetClaims(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new AuthResponseModel { IsAuthSuccessful = true, Token = token };
    }

    public async Task<RegisterResponseModel> RegisterUser(AuthModel userForAuthentication)
    {
        if (userForAuthentication == null)
            return new RegisterResponseModel { Errors = new List<string> { "Null" }, IsSuccess = false };
        var user = new UserEntity { UserName = userForAuthentication.Email, Email = userForAuthentication.Email };

        var result = await _userManager.CreateAsync(user, userForAuthentication.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return new RegisterResponseModel { Errors = errors.ToList(), IsSuccess = false };
        }
        await _userManager.AddToRoleAsync(user, "Viewer");

        return new RegisterResponseModel { IsSuccess = true };
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration.SecurityKey);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }


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