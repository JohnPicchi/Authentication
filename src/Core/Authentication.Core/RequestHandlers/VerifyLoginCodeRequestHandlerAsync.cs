﻿using System;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class VerifyLoginCodeRequestHandlerAsync : IRequestHandlerAsync<VerifyLoginCodeEditModel, SignInResult>
  {
    public async Task<SignInResult> HandleAsync(VerifyLoginCodeEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
