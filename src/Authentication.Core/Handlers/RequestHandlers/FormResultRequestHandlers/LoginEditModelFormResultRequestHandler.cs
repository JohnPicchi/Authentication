using Authentication.Core.Contracts.HandlerContracts;
using Authentication.Core.Handlers.RequestHandlers.FormResults;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.Handlers.RequestHandlers.FormResultRequestHandlers
{
  public class LoginEditModelFormResultRequestHandler : IFormResultRequestHandler<LoginEditModel>
  {
    public IFormResult Handle(LoginEditModel request)
    {
      return FormResult.Ok;
    }
  }
}
