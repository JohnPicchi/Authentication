using System;
using Authentication.Core.Contracts.HandlerContracts;
using Authentication.Core.Handlers.RequestHandlers.FormResults;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.Handlers.RequestHandlers.FormResultHandlers
{
  public class RegisterEditModelFormResultRequestHandler : IFormResultRequestHandler<RegisterEditModel>
  {
    public IFormResult Handle(RegisterEditModel request)
    {
      return FormResult.Ok;
    }
  }
}
