using AutoMapper;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Mapping;

public class AuthModelProfile: Profile
{
    public AuthModelProfile()
    {
        CreateMap<LoginModel, LoginViewModel>().ReverseMap();
        CreateMap<RegisterModel, RegisterViewModel>().ReverseMap();
    }
}