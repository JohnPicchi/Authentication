using Authentication.Core.Contracts;
using Authentication.Core.Contracts.Handlers;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.Handlers.RequestHandlers.FormResultRequests
{
  public class RegisterEditModelFormResultRequestHandler : IFormResultRequestHandler<RegisterEditModel>
  {
    public IFormResult Handle(RegisterEditModel request)
    {
      return FormResult.Ok;
    }
  }
}
