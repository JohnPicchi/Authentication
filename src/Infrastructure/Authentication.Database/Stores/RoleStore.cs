using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.User.PersistenceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Database.Stores
{
  public class RoleStore : RoleStore<Role, DatabaseContext, Guid, UserRole, RoleClaim>
  {
    public RoleStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }

    protected override RoleClaim CreateRoleClaim(Role role, Claim claim)
    {
      throw new NotImplementedException();
      // var roleClaim = new RoleClaim { RoleId = role.Id };
      // roleClaim.InitializeFromClaim(claim);
      // return roleClaim;
    }
  }
}
