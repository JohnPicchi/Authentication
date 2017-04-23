using Authentication.Core.Contracts.HandlerContracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.Handlers.FormHandlers
{
  public class RegisterEditModelFormHandler : IFormHandler<RegisterEditModel>
  {
    public IFormResult Handle(RegisterEditModel form)
    {
      return FormResult.Fail("Registration is closed.");
    }
  }
}
