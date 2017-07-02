using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class ResetPasswordEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<ResetPasswordEditModel>
  {
    private readonly UserManager<User.Models.User> userManager;

    public ResetPasswordEditModelRequestHandlerAsync(UserManager<User.Models.User> userManager)
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
      return FormResult.Ok;
    }
  }
}
