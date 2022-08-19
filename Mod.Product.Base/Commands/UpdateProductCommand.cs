using MediatR;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Commands;

public record UpdateProductCommand(ProductModel Product) : IRequest<ProductModel>;