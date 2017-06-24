using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.PersistenceModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.User.Stores
{
  public interface IRoleStore : 
    IQueryableRoleStore<Role>, 
    IRoleStore<Role>, 
    IRoleClaimStore<Role>,
    IDisposable
  {
  }
}
