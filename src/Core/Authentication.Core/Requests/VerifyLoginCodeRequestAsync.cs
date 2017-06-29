using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Requests
{
  public class VerifyLoginCodeRequestAsync : IRequestAsync<SignInResult, VerifyLoginCodeEditModel>
  {
    private readonly IRequestHandlerAsync<VerifyLoginCodeEditModel, SignInResult> requestHandler;

    public VerifyLoginCodeRequestAsync(IRequestHandlerAsync<VerifyLoginCodeEditModel, SignInResult> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public async Task<SignInResult> HandleAsync(VerifyLoginCodeEditModel request) => await requestHandler.HandleAsync(request);
  }
}
