using System.Net.Http;
using System.Threading;
using Authentication.Core.Contracts.HandlerContracts;
using Authentication.PresentationModels.EditModels;
using IdentityServer4.Extensions;
using IdentityServer4.Services;

namespace Authentication.Core.Handlers.FormHandlers
{
  public class LoginEditModelFormHandler : IFormHandler<LoginEditModel>
  {
    private IIdentityServerInteractionService interactionService;

    public LoginEditModelFormHandler(IIdentityServerInteractionService interactionService)
    {
      this.interactionService = interactionService;
    }

    public IFormResult Handle(LoginEditModel form)
    {
      return FormResult.Ok;
    }
  }
}
