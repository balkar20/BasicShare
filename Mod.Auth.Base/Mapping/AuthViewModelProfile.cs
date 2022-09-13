using AutoMapper;
using Core.Auh.Entities;
using Core.Base.DataBase.Entities;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Mapping;

public class AuthViewModelProfile: Profile
{
    public AuthViewModelProfile()
    {
        CreateMap<AuthModel, AuthViewModel>().ReverseMap();
    }
}