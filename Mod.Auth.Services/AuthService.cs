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
using Core.Auh.Enums;
using Core.Transfer;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

namespace Mod.Auth.Base.Repositories;

public class AuthService: IAuthService
{
    //private readonly IAuthRepository _repository;
    private readonly ILogger _logger;
    private SignInManager<UserEntity> _signManager;
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

    public async Task<List<PooperModel>> GetAllPoopers()
    {
        var users = await _userManager.GetUsersInRoleAsync("Pooper");
        var poopers = users?.Select(p => new PooperModel(
        
            p.Id,
            p.AmountOfPoops,
            p.UserName,
            p.Image
        ))?.ToList();

        return poopers;
    }

    public async Task<LoginResponseModel> LogIn(LoginModel userForAuthentication)
    {
        var user = await _userManager.FindByEmailAsync(userForAuthentication.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            return new LoginResponseModel { ErrorMessage = "Invalid Authentication" };
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaimsAsync(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new LoginResponseModel { IsAuthSuccessful = true, Token = token };
    }


    public async Task<RegisterResponseModel> RegisterUser(RegisterModel registerModel)
    {
        if (registerModel == null)
            return new RegisterResponseModel { Errors = new List<string> { "Null" }, IsSuccess = false };
        var user = new UserEntity { UserName = registerModel.UserName, Email = registerModel.Email, Year = registerModel.Year };

        var result = await _userManager.CreateAsync(user, registerModel.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return new RegisterResponseModel { Errors = errors.ToList(), IsSuccess = false };
        }

        await _userManager.AddToRoleAsync(user, registerModel.UserRole is null ? UserRolesEnum.Viewer.ToString() : registerModel.UserRole.ToString());

        return new RegisterResponseModel { IsSuccess = true };
    }

    public async Task<BaseResponseResult> SavePooper(PooperModel pooperModel)
    {
        var responce = new BaseResponseResult()
        {
            IsSuccess = false
        };
        
        var user = await _userManager.FindByIdAsync(pooperModel.Id);
        if (user == null)
        {
            return responce;
        }

        if (user != null)
        {
            user.UserName = pooperModel.PooperAlias;
            user.AmountOfPoops = pooperModel.AmountOfPoops;
            user.Image = pooperModel.Image;
            await _userManager.UpdateAsync(user);
            responce.IsSuccess = true;
        }
        
        return responce;
    }


    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration.SecurityKey);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaimsAsync(UserEntity user)
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