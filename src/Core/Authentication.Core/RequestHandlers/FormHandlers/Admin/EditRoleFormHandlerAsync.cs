using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Stores;

namespace Authentication.Core.RequestHandlers.FormHandlers.Admin
{
  public class EditRoleFormHandlerAsync : IFormHandlerAsync<EditRoleEditModel>
  {
    private readonly IRoleStore roleStore;

    public EditRoleFormHandlerAsync(IRoleStore roleStore)
    {
      this.roleStore = roleStore;
    }

    public async Task<IFormResult> HandleAsync(EditRoleEditModel request)
    {
      var role = await roleStore.FindByIdAsync(request.Id.ToString(), CancellationToken.None);
      if (role.Name != request.Name)
        await roleStore.SetRoleNameAsync(role, request.Name, CancellationToken.None);

      return FormResult.Success;
    }
  }
}
