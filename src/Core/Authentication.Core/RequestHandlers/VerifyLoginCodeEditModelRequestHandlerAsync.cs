using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class VerifyLoginCodeEditModelRequestHandlerAsync : IRequestHandlerAsync<VerifyLoginCodeEditModel, SignInResult>
  {
    public async Task<SignInResult> HandleAsync(VerifyLoginCodeEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
