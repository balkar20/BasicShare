// using MediatR;

using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Queries;

public record GetAllAuthsQuery : IRequest<List<LoginModel>>;