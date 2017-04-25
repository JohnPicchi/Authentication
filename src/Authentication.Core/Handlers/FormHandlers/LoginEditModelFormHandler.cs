using System.Net.Http;
using System.Threading;
using Authentication.Core.Contracts.HandlerContracts;
using Authentication.Core.Contracts.ServiceContracts;
using Authentication.PresentationModels.EditModels;
using IdentityServer4.Services;

namespace Authentication.Core.Handlers.FormHandlers
{
  public class LoginEditModelFormHandler : IFormHandler<LoginEditModel>
  {
    private IIdentityServerInteractionService interactionService;
    private IPasswordService passwordService;

    public LoginEditModelFormHandler(IIdentityServerInteractionService interactionService, IPasswordService passwordService)
    {
      this.interactionService = interactionService;
      this.passwordService = passwordService;
    }

    public IFormResult Handle(LoginEditModel form)
    {
      return FormResult.Ok;
    }
  }
}
