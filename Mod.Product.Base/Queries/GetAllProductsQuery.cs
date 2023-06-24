// using MediatR;

using Core.Base.Output;
using Core.Transfer;
using MediatR;
using Mod.Product.Base.ViewModels;
using Mod.Product.Models;

namespace Mod.Product.Base.Queries;

public record GetAllProductsQuery : IRequest<ResponseResultWithData<List<ProductModel>>>;