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
  public class UserStore : UserStore<User.PersistenceModels.User, Role, DatabaseContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
  {
    public UserStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }

    protected override UserRole CreateUserRole(User.PersistenceModels.User user, Role role)
    {
      return null;
    }

    protected override UserClaim CreateUserClaim(User.PersistenceModels.User user, Claim claim)
    {
      return null;
    }

    protected override UserLogin CreateUserLogin(User.PersistenceModels.User user, UserLoginInfo login)
    {
      return null;
    }

    protected override UserToken CreateUserToken(User.PersistenceModels.User user, string loginProvider, string name, string value)
    {
      return null;
    }
  }
}
