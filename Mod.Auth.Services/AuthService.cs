using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Serilog;
using Core.Auh.Configuration;
using Core.Auh.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Core.Auh.Enums;
using Core.Transfer;
using Data.IdentityDb;
using Microsoft.EntityFrameworkCore;

namespace Mod.Auth.Base.Repositories;

public class AuthService: IAuthService
{
    //private readonly IAuthRepository _repository;
    private readonly ILogger _logger;
    private SignInManager<UserEntity> _signManager;
    private UserManager<UserEntity> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    private ApplicationContext _context;
    private readonly AuthConfiguration _configuration;
    private readonly IMapper _mapper;


    public AuthService(
        ILogger logger,
        AuthConfiguration authConfiguration,
        UserManager<UserEntity> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationContext context, IMapper mapper)
    {
        _logger = logger;
        _configuration = authConfiguration;
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PooperModel>> GetAllPoopers()
    {
        var usersWithClaims = await _context.Users.GroupJoin(
            _context.UserClaims,
            u => u.Id,
            c => c.UserId,
            (u, cl) => new PooperModel()
            {
                Id = u.Id,
                AmountOfPoops = u.AmountOfPoops,
                PooperAlias = u.UserName,
                Description = u.Description,
                Image = u.Image,
                Claims = cl.Select(c => c.ClaimValue).ToList()
            }).ToListAsync();

        return usersWithClaims;
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

        var claims = await GetClaimsAsync(user);
        var signingCredentials = GetSigningCredentials();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new RegisterResponseModel { IsSuccess = true, Token = token};
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