using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Commands;

public record CreateAuthCommand(UserModel Auth) : IRequest<UserModel>;