using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers
{
  public class SendLoginCodeEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<SendLoginCodeEditModel>
  {
    public async Task<IFormResult> HandleAsync(SendLoginCodeEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
