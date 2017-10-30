using System;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class VerifyLoginCodeRequestHandler : IRequestHandler<VerifyLoginCodeEditModel, SignInResult>
  {
    public async Task<SignInResult> HandleAsync(VerifyLoginCodeEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
