using Core.Auh.Entities;
using Infrastructure.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthRepository: IRepository<UserEntity, LoginModel>
{
}