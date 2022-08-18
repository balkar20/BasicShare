using MediatR;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Commands;

public class CreateProductCommand: IRequest<ProductModel>
{
    public ProductModel Product { get; set; } 
}