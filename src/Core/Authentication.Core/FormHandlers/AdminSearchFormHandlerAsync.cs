using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.PresentationModels.Admin.ViewModels;

namespace Authentication.Core.FormHandlers
{
  public class AdminSearchFormHandlerAsync : IFormHandlerAsync<AdminSearchViewModel>
  {
    public async Task<IFormResult> HandleAsync(AdminSearchViewModel request)
    {
      if (request.Kind is SearchKind.User)
        return await HandleUserSearchAsync(request);
      return await HandleRoleSearchAsync(request);
    }

    private async Task<IFormResult> HandleUserSearchAsync(AdminSearchViewModel request)
    {
      throw new NotImplementedException();
    }

    private async Task<IFormResult> HandleRoleSearchAsync(AdminSearchViewModel request)
    {
      throw new NotImplementedException();
    }
  }
}
