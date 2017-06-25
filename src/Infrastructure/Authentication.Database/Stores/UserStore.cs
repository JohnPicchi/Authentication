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
  public class UserStore : UserStore<User.PersistenceModels.User, Role, DatabaseContext, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, UserLogin, UserToken, IdentityRoleClaim<Guid>>
  {
    public UserStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {

    }

    protected override IdentityUserRole<Guid> CreateUserRole(User.PersistenceModels.User user, Role role)
    {
      return new IdentityUserRole<Guid>()
      {
        UserId = user.Id,
        RoleId = role.Id
      };
    }

    protected override IdentityUserClaim<Guid> CreateUserClaim(User.PersistenceModels.User user, Claim claim)
    {
      var userClaim = new IdentityUserClaim<Guid> { UserId = user.Id };
      userClaim.InitializeFromClaim(claim);
      return userClaim;
    }

    protected override UserLogin CreateUserLogin(User.PersistenceModels.User user, UserLoginInfo login)
    {
      return new UserLogin
      {
        UserId = user.Id,
        ProviderKey = login.ProviderKey,
        LoginProvider = login.LoginProvider,
        ProviderDisplayName = login.ProviderDisplayName
      };
    }

    protected override UserToken CreateUserToken(User.PersistenceModels.User user, string loginProvider, string name, string value)
    {
      return new UserToken
      {
        UserId = user.Id,
        LoginProvider = loginProvider,
        Name = name,
        Value = value
      };
    }
  }
}
