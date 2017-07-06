using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class ConfirmPhoneNumberEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<ConfirmPhoneNumberEditModel>
  {
    private readonly HttpContext httpContext;
    private readonly UserManager<User.Models.User> userManager;

    public ConfirmPhoneNumberEditModelRequestHandlerAsync(
      UserManager<User.Models.User> userManager,
      IHttpContextAccessor httpContextAccessor)
    {
      this.userManager = userManager;
      this.httpContext = httpContextAccessor.HttpContext;
    }

    public async Task<IFormResult> HandleAsync(ConfirmPhoneNumberEditModel request)
    {
      var user = await userManager.GetUserAsync(httpContext.User);
      if (user != null)
      {
        var result = await userManager.VerifyChangePhoneNumberTokenAsync(user, request.SecurityCode, user.PhoneNumber);
        if (result)
        {
          user.PhoneNumberConfirmed = true;
          return FormResult.Ok;
        }
        return FormResult.Fail("Invalid confirmation code");
      }
      return FormResult.Fail("Unable to confirm phone number due to an error");
    }
  }
}
