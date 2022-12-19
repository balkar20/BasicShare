using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Product.Base.ViewModels;
using ModProduct.Models;

namespace Mod.Product.Base.Mapping;

public class ProductViewModelProfile: Profile
{
    public ProductViewModelProfile()
    {
        CreateMap<ProductModel, ProductViewModel>().ReverseMap();
    }
}