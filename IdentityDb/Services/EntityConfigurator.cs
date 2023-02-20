using Core.Auh.Entities;
using IdentityDb.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityDb.Services;

public class EntityConfigurator
{
     UserConfiguration UserEntityConfiguraton;
    private RoleConfiguration RoleEntityConfiguraton;
    private UserRoleConfiguration UserRoleEntityConfiguraton;
    private UserClaimConfiguration ClaimUserConfiguraton;
}