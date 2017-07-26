using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Admin
{
  public class EditRoleFormHandlerAsync : IFormHandlerAsync<EditRoleEditModel>
  {
    private readonly RoleManager<Role> roleManager;

    public EditRoleFormHandlerAsync(RoleManager<Role> roleManager)
    {
      this.roleManager = roleManager;
    }

    public async Task<IFormResult> HandleAsync(EditRoleEditModel request)
    {
      var role = await roleManager.FindByIdAsync(request.RoleId.ToString());
      if (role.Name != request.RoleName)
      {
        var result = await roleManager.SetRoleNameAsync(role, request.RoleName);
        return result.Succeeded
          ? FormResult.Success
          : FormResult.Fail(result.Errors?.FirstOrDefault()?.Description ?? "Unable to set role name");
      }
      return FormResult.Success;
    }
  }
}
