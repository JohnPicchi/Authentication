using System;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Account.EditModels;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class SendLoginCodeFormHandlerAsync : IFormHandlerAsync<SendLoginCodeEditModel>
  {
    public async Task<IFormResult> HandleAsync(SendLoginCodeEditModel request)
    {
      throw new NotImplementedException();
    }
  }
}
