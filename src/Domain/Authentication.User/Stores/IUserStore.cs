using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.User.Stores
{
  public interface IUserStore : 
    IUserLoginStore<Models.User>, 
    IUserRoleStore<Models.User>, 
    IUserClaimStore<Models.User>, 
    IUserPasswordStore<Models.User>, 
    IUserSecurityStampStore<Models.User>, 
    IUserEmailStore<Models.User>, 
    IUserLockoutStore<Models.User>, 
    IUserPhoneNumberStore<Models.User>, 
    IQueryableUserStore<Models.User>, 
    IUserTwoFactorStore<Models.User>, 
    IUserAuthenticationTokenStore<Models.User>,
    IUserStore<Models.User>,
    IDisposable
  {
    Task<bool> AccountExistsAsync(string email);
  }
}
