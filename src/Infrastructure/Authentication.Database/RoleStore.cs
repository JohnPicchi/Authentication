using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Authentication.Database.Contexts;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Database
{
  public class RoleStore : RoleStore<Role, DatabaseContext, Guid, UserRole, RoleClaim>
  {
    public RoleStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }

    protected override RoleClaim CreateRoleClaim(Role role, Claim claim)
    {
      throw new NotImplementedException();
    }
  }
}
