using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.User.Models;
using Authentication.User.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Database.Stores
{
  public class RoleStore : RoleStore<Role, DatabaseContext, Guid>, IRoleStore
  {
    public RoleStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }
  }
}