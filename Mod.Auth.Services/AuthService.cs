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
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Core.Auh.Enums;
using Core.Transfer;
using Data.IdentityDb;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

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
        IOptions<AuthConfiguration> options,
        UserManager<UserEntity> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationContext context, IMapper mapper)
    {
        _logger = logger;
        _configuration = options.Value;
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PooperModel>> GetAllPoopers()
    {
        // var users = await _userManager.GetUsersInRoleAsync("Pooper");
        
        // var pooperRole = _roleManager.Roles.Where(r => r.Name == UserRolesEnum.Pooper.ToString()).SingleOrDefault();
        // var users = await _userManager.GetUsersInRoleAsync("Pooper");
        
        // var role = await _roleManager.Roles
        //     .Where(u => string.Equals(u.Name, UserRolesEnum.Pooper.ToString()))
        //     .SingleOrDefaultAsync();
        
            // var usersWithClaims = (from user in _context.Users
            //     join userClaim in _context.UserClaims on user.Id equals userClaim.UserId 
            //     group new {user.Id, userClaim.UserId} 
            //     by new {user, userClaim.UserId} into g
            //     select new PooperModel()
            //     {
            //         Id = g.Key.user.Id,
            //         AmountOfPoops = g.Key.user.AmountOfPoops,
            //         PooperAlias = g.Key.user.UserName,
            //         Image = g.Key.user.Image,
            //         Description = g.Key.user.Description,
            //         Claims = new List<string?>()
            //     }).ToList();
                
        // var users = _context.Users
        //     .GroupJoin(_context.UserClaims,
        //         u => u.Id,
        //         c => c.UserId,
        //         (u, c) => Tuple.Create(u, c)
        //     ).SelectMany(
        //         x => x.Item2.DefaultIfEmpty(),
        //         (userEntity, claims) => new PooperModel(
        //             userEntity.Item1.Id,
        //             userEntity.Item1.AmountOfPoops,
        //             userEntity.Item1.UserName,
        //             userEntity.Item1.Image,
        //             userEntity.Item1.Description,
        //             userEntity.Item2.Select(cl => cl.ClaimValue).ToList()
        //         ))
        // var users = await _userManager.GetUsersInRoleAsync(UserRolesEnum.Pooper.ToString());
        // var poopers = users?.Select(p => new PooperModel(
        //
        //     p.Id,
        //     p.AmountOfPoops,
        //     p.UserName,
        //     p.Image,
        //     p.Description,
        //     new List<string>()
        // ))?.ToList();
        
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