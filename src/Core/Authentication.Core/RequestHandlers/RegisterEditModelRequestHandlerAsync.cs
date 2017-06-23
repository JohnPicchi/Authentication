using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers
{
  public class RegisterEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<RegisterEditModel>
  {
    public async Task<IFormResult> HandleAsync(RegisterEditModel registerEditModel)
    {
      return FormResult.Ok;
    }
  }
}