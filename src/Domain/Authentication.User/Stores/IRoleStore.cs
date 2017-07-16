using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.User.Stores
{
  public interface IRoleStore : 
    IQueryableRoleStore<Role>, 
    IRoleStore<Role>, 
    IRoleClaimStore<Role>,
    IDisposable
  {
    Task<bool> RoleNameExistsAsync(string roleName);
  }
}