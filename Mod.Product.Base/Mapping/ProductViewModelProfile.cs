using AutoMapper;
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