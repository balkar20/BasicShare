using MediatR;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Commands;

public record LoginCommand(AuthViewModel Auth) : IRequest<AuthResponseModel>;