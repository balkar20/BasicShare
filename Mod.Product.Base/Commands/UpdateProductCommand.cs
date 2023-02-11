using MediatR;
using Mod.Product.Models;

namespace Mod.Product.Base.Commands;

public record UpdateProductCommand(ProductModel Product) : IRequest<ProductModel>;