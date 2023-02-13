// using MediatR;

using Core.Transfer;
using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Queries;

public record GetAllAuthsQuery : IRequest<ResponseResultWithData<List<PooperModel>>>;