using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Authentication.User.Stores;

namespace Authentication.Database.Stores
{
  public class UserStore : UserStore<User.Models.User, Role, DbContext, Guid>, IUserStore
  {
    public UserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }

    public async Task<bool> AccountExistsAsync(string email)
    {
      return await Users.AnyAsync(u => u.Email == email);
    }
  }
}
