// using MediatR;

using Core.Base.Output;
using MediatR;
using Mod.Product.Base.ViewModels;

namespace Mod.Product.Base.Queries;

public record GetTempQuery : IRequest<string>;