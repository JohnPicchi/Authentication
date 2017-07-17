using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Admin
{
  public class AddRoleClaimFormHandlerAsync : IFormHandlerAsync<AddRoleClaimEditModel>
  {
    private readonly RoleManager<Role> roleManager;

    public AddRoleClaimFormHandlerAsync(RoleManager<Role> roleManager)
    {
      this.roleManager = roleManager;
    }

    public async Task<IFormResult> HandleAsync(AddRoleClaimEditModel request)
    {
      var role = await roleManager.FindByIdAsync(request.RoleId.ToString());
      if (role != null)
      {
        var claim = new Claim(request.Type, request.Value);
        await roleManager.AddClaimAsync(role, claim);
        return FormResult.Success;
      }
      return FormResult.Fail("Unable to add role claim");
    }
  }
}
