using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.User.Stores
{
  public interface IUserStore : 
    IUserLoginStore<PersistenceModels.User>, 
    IUserRoleStore<PersistenceModels.User>, 
    IUserClaimStore<PersistenceModels.User>, 
    IUserPasswordStore<PersistenceModels.User>, 
    IUserSecurityStampStore<PersistenceModels.User>, 
    IUserEmailStore<PersistenceModels.User>, 
    IUserLockoutStore<PersistenceModels.User>, 
    IUserPhoneNumberStore<PersistenceModels.User>, 
    IQueryableUserStore<PersistenceModels.User>, 
    IUserTwoFactorStore<PersistenceModels.User>, 
    IUserAuthenticationTokenStore<PersistenceModels.User>,
    IUserStore<PersistenceModels.User>,
    IDisposable
  {
  }
}
