// using MediatR;

using Core.Base.Output;
using MediatR;
using Mod.Product.Base.ViewModels;
using ModProduct.Models;

namespace Mod.Product.Base.Queries;

public record GetAllProductsQuery : IRequest<OutputViewModelWithData<List<ProductViewModel>>>;