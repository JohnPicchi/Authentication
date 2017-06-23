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
  public class UserStore : UserStore<User, Role, DatabaseContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
  {
    public UserStore(DatabaseContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }

    protected override UserRole CreateUserRole(User user, Role role)
    {
      throw new NotImplementedException();
    }

    protected override UserClaim CreateUserClaim(User user, Claim claim)
    {
      throw new NotImplementedException();
    }

    protected override UserLogin CreateUserLogin(User user, UserLoginInfo login)
    {
      throw new NotImplementedException();
    }

    protected override UserToken CreateUserToken(User user, string loginProvider, string name, string value)
    {
      throw new NotImplementedException();
    }
  }
}
