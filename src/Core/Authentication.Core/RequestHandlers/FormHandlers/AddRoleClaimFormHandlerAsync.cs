using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Stores;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers
{
  public class AddRoleClaimFormHandlerAsync : IFormHandlerAsync<AddRoleClaimEditModel>
  {
    private readonly IRoleStore roleStore;

    public AddRoleClaimFormHandlerAsync(IRoleStore roleStore)
    {
      this.roleStore = roleStore;
    }

    public async Task<IFormResult> HandleAsync(AddRoleClaimEditModel request)
    {
      var role = await roleStore.FindByIdAsync(request.RoleId.ToString(), CancellationToken.None);
      if (role != null)
      {
        var claim = new Claim(request.Type, request.Value);
        await roleStore.AddClaimAsync(role, claim, CancellationToken.None);
        return FormResult.Success;
      }
      return FormResult.Fail("Unable to add role claim");
    }
  }
}
