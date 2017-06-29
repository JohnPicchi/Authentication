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
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database.Stores
{
  public class UserStore : UserStore<User.Models.User, Role, DatabaseContext, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, UserLogin, UserToken, IdentityRoleClaim<Guid>>, IUserStore
  {
    public UserStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {

    }

    protected override IdentityUserRole<Guid> CreateUserRole(User.Models.User user, Role role)
    {
      return new IdentityUserRole<Guid>()
      {
        UserId = user.Id,
        RoleId = role.Id
      };
    }

    protected override IdentityUserClaim<Guid> CreateUserClaim(User.Models.User user, Claim claim)
    {
      var userClaim = new IdentityUserClaim<Guid> { UserId = user.Id };
      userClaim.InitializeFromClaim(claim);
      return userClaim;
    }

    protected override UserLogin CreateUserLogin(User.Models.User user, UserLoginInfo login)
    {
      return new UserLogin
      {
        UserId = user.Id,
        ProviderKey = login.ProviderKey,
        LoginProvider = login.LoginProvider,
        ProviderDisplayName = login.ProviderDisplayName
      };
    }

    protected override UserToken CreateUserToken(User.Models.User user, string loginProvider, string name, string value)
    {
      return new UserToken
      {
        UserId = user.Id,
        LoginProvider = loginProvider,
        Name = name,
        Value = value
      };
    }

    public async Task<bool> AccountExistsAsync(string email)
    {
      return await Users.AnyAsync(u => u.Email == email);
    }
  }
}
