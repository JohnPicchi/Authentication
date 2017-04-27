using Authentication.Core.Contracts;
using Authentication.Core.Contracts.Handlers;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.Handlers.RequestHandlers.FormResultRequests
{
  public class LoginEditModelFormResultRequestHandler : IFormResultRequestHandler<LoginEditModel>
  {
    public IFormResult Handle(LoginEditModel request)
    {
      return FormResult.Ok;
    }
  }
}
