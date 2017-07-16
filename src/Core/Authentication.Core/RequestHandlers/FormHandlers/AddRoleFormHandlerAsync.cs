using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Models;
using Authentication.User.Stores;

namespace Authentication.Core.RequestHandlers.FormHandlers
{
  public class AddRoleFormHandlerAsync : IFormHandlerAsync<AddRoleEditModel>
  {
    private readonly IRoleStore roleStore;
    public AddRoleFormHandlerAsync(IRoleStore roleStore)
    {
      this.roleStore = roleStore;
    }

    public async Task<IFormResult> HandleAsync(AddRoleEditModel request)
    {
      var role = new Role
      {
        Name = request.RoleName,
        NormalizedName = request.RoleName.ToUpper()
      };
      var result = await roleStore.CreateAsync(role, CancellationToken.None);

    return result.Succeeded
        ? FormResult.Success
        : FormResult.Fail(result.Errors.FirstOrDefault()?.Description ?? "There was an error creating the role");
    }
  }
}
