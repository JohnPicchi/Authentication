using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Core.RequestHandlers.FormHandlers.Admin
{
  public class DeleteRoleClaimFormHandlerAsync : IFormHandlerAsync<DeleteRoleClaimEditModel>
  {
    private readonly RoleManager<Role> roleManager;

    public DeleteRoleClaimFormHandlerAsync(RoleManager<Role> roleManager)
    {
      this.roleManager = roleManager;
    }

    public async Task<IFormResult> HandleAsync(DeleteRoleClaimEditModel request)
    {
      var role = await roleManager.Roles
        .Where(r => r.Id == request.RoleId)
        .Include(r => r.Claims)
        .SingleAsync();

      var claim = role?.Claims
        .Single(r => r.Id == request.RoleClaimId)
        .ToClaim();

      if (claim != null)
      {
        var result = await roleManager.RemoveClaimAsync(role, claim);
        return result.Succeeded
          ? FormResult.Success
          : FormResult.Fail(result.Errors?.FirstOrDefault()?.Description ?? "Unable to delete role claim due to an error");
      }

      var errorMessage = "Unable to delete role claim due to an error";
      if (role is null)
        errorMessage = "Unable to locate role to delete the requested role claim";
      else if (claim is null)
        errorMessage = "Unable to locate role claim";

      return FormResult.Fail(errorMessage);
    }
  }
}
