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

namespace Authentication.Core.RequestHandlers.FormHandlers.Admin
{
  public class DeleteRoleFormHandlerAsync : IFormHandlerAsync<DeleteRoleEditModel>
  {
    private readonly RoleManager<Role> roleManager;

    public DeleteRoleFormHandlerAsync(RoleManager<Role> roleManager)
    {
      this.roleManager = roleManager;
    }

    public async Task<IFormResult> HandleAsync(DeleteRoleEditModel request)
    {
      var role = await roleManager.FindByIdAsync(request.RoleId.ToString());
      if (role != null)
      {
        var result = await roleManager.DeleteAsync(role);
        if (result.Succeeded)
          return FormResult.Success;
        return FormResult.Fail(result.Errors?.FirstOrDefault()?.Description ?? "Unable to delete role due to an error");
      }
      return FormResult.Fail("Unable to locate and delete role");
    }
  }
}
