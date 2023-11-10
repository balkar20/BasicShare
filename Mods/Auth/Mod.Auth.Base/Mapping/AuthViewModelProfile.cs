using AutoMapper;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Mapping;

public class AuthViewModelProfile: Profile
{
    public AuthViewModelProfile()
    {
        CreateMap<LoginModel, LoginViewModel>().ReverseMap();
        CreateMap<RegisterModel, RegisterViewModel>().ReverseMap();
    }
}