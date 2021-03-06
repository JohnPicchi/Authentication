﻿using System;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Account.EditModels;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class AccountSettingsFormHandlerAsync : IFormHandlerAsync<AccountSettingsEditModel>
  {
    public async Task<IFormResult> HandleAsync(AccountSettingsEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
