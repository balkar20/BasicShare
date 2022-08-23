using AutoMapper;
using Core.Base.DataBase.Entities;
using ModProduct.Models;

namespace Mod.Product.Base.Mapping;

public class ProductModelProfile: Profile
{
    public ProductModelProfile()
    {
        CreateMap<ProductModel, ProductEntity>().ReverseMap();
    }
}