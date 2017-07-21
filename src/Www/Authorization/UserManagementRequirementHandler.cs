using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Authentication.Authorization
{
  public class UserManagementRequirement : IAuthorizationRequirement
  {
    
  }

  public class UserManagementRequirementHandler : AuthorizationHandler<UserManagementRequirement>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserManagementRequirement requirement)
    {
      context.Succeed(requirement);
      return Task.CompletedTask;
    }
  }
}