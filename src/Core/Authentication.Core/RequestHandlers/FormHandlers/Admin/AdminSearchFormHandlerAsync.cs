﻿using System;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.PresentationModels.Admin.ViewModels;

namespace Authentication.Core.RequestHandlers.FormHandlers.Admin
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
