using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Authentication.User.Stores
{
  public interface IUserStore : 
    IUserLoginStore<Models.User>, 
    IUserStore<Models.User>, 
    IDisposable, 
    IUserRoleStore<Models.User>, 
    IUserClaimStore<Models.User>, 
    IUserPasswordStore<Models.User>, 
    IUserSecurityStampStore<Models.User>, 
    IUserEmailStore<Models.User>, 
    IUserLockoutStore<Models.User>, 
    IUserPhoneNumberStore<Models.User>, 
    IQueryableUserStore<Models.User>, 
    IUserTwoFactorStore<Models.User>, 
    IUserAuthenticationTokenStore<Models.User>
  {
  }
}
