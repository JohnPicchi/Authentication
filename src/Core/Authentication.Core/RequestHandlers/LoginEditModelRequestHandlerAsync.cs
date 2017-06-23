using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers
{
  public class LoginEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<LoginEditModel>
  {
    public Task<IFormResult> HandleAsync(LoginEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
