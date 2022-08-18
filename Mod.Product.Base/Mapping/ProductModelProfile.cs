using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Mapping;

public class ProductModelProfile: Profile
{
    public ProductModelProfile()
    {
        CreateMap<ProductModel, ProductEntity>().ReverseMap();
    }
}