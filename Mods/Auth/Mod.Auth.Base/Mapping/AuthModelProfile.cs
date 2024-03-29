using AutoMapper;
using Core.Auh.Entities;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Mapping;

public class AuthModelProfile: Profile
{
    public AuthModelProfile()
    {
        CreateMap<LoginModel, LoginViewModel>().ReverseMap();
        CreateMap<RegisterModel, RegisterViewModel>().ReverseMap();
        CreateMap<UserEntity, UserModel>()
            .ForMember(dest => dest.Claims, opt =>
                opt.MapFrom(src => src.Claims != null 
                    ? src.Claims.Select(c => c.ClaimValue).ToList() 
                    : null))
            .ForMember(model => 
                    model.UserName, 
                entity => 
                    entity.MapFrom(e => e.UserName))
            .ForMember(model => 
                    model.Description, 
                entity => 
                    entity.MapFrom(e => e.Description))
            .ForMember(model => 
                    model.Image, 
                entity => 
                    entity.MapFrom(e => e.Image))
            .ReverseMap();
    }
}