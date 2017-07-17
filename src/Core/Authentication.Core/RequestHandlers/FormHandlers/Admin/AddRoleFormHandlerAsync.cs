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
  public class AddRoleFormHandlerAsync : IFormHandlerAsync<AddRoleEditModel>
  {
    private readonly RoleManager<Role> roleManager;

    public AddRoleFormHandlerAsync(RoleManager<Role> roleManager)
    {
      this.roleManager = roleManager;
    }

    public async Task<IFormResult> HandleAsync(AddRoleEditModel request)
    {
      var role = new Role { Name = request.Name };
      var result = await roleManager.CreateAsync(role);
      return result.Succeeded
        ? FormResult.Success
        : FormResult.Fail(result.Errors.FirstOrDefault()?.Description ?? "There was an error creating the role");
    }
  }
}
