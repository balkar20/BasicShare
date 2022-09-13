using Core.Auh.Entities;
using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthRepository: IRepository<UserEntity, AuthModel>
{
}