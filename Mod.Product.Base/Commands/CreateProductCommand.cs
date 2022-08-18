using MediatR;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Commands;

public record CreateProductCommand(ProductModel Product) : IRequest<ProductModel>;