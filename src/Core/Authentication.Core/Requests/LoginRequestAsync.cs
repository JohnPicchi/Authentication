using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Requests
{
  public class LoginRequestAsync : IRequestAsync<SignInResult, LoginEditModel>
  {
    private readonly IRequestHandlerAsync<LoginEditModel, SignInResult> requestHandler;

    public LoginRequestAsync(IRequestHandlerAsync<LoginEditModel, SignInResult> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public async Task<SignInResult> HandleAsync(LoginEditModel request) => await requestHandler.HandleAsync(request);
  }
}
