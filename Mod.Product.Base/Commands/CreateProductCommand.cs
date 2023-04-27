using Core.Transfer;
using MediatR;
using Mod.Product.Models;

namespace Mod.Product.Base.Commands;

public record CreateProductCommand(ProductModel Product) : IRequest<BaseResponseResult>;