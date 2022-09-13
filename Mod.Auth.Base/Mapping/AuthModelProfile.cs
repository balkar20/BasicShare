using AutoMapper;
using Core.Auh.Entities;
using Core.Base.DataBase.Entities;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Mapping;

public class AuthModelProfile: Profile
{
    public AuthModelProfile()
    {
        CreateMap<AuthModel, UserEntity>().ReverseMap();
    }
}