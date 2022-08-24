using MediatR;
using ModProduct.Models;

namespace Mod.Product.Base.Commands;

public record UpdateProductCommand(ProductModel Product) : IRequest<ProductModel>;