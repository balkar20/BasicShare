using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Commands;

public record CreateAuthCommand(AuthModel Auth) : IRequest<AuthModel>;