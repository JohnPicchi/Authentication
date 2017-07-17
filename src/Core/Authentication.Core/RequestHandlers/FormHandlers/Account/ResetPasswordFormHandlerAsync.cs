using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class ResetPasswordFormHandlerAsync : IFormHandlerAsync<ResetPasswordEditModel>
  {
    private readonly UserManager<User.Models.User> userManager;

    public ResetPasswordFormHandlerAsync(UserManager<User.Models.User> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<IFormResult> HandleAsync(ResetPasswordEditModel request)
    {
      var user = await userManager.FindByEmailAsync(request.Email);
      if (user != null)
      {
        var result = userManager.ResetPasswordAsync(user, request.Code, request.Password);
      }
      return FormResult.Success;
    }
  }
}
