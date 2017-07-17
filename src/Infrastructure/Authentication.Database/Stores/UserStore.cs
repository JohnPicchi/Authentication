using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Authentication.User.Stores;

namespace Authentication.Database.Stores
{
  public class UserStore : UserStore<User.Models.User, Role, DatabaseContext, Guid>, IUserStore
  {
    public UserStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }
  }
}