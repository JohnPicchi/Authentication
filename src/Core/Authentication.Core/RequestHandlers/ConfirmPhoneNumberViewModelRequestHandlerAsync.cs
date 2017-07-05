using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers
{
  public class ConfirmPhoneNumberEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<ConfirmPhoneNumberEditModel>
  {
    public async Task<IFormResult> HandleAsync(ConfirmPhoneNumberEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
