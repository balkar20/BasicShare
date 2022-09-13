using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Commands;

public record UpdateAuthCommand(AuthModel Auth) : IRequest<AuthModel>;