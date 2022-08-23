using MediatR;
using ModProduct.Models;

namespace Mod.Product.Base.Commands;

public record CreateProductCommand(ProductModel Product) : IRequest<ProductModel>;