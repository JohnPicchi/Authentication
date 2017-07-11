using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Core.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Core.ServiceContracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.FormHandlers
{
  public class ForgotPasswordFormHandlerAsync : IFormHandlerAsync<ForgotPasswordEditModel>
  {
    private readonly UserManager<User.Models.User> userManager;
    private readonly HttpContext httpContext;
    private readonly IEmailService emailService;

    public ForgotPasswordFormHandlerAsync(
      UserManager<User.Models.User> userManager, 
      IHttpContextAccessor httpContext,
      IEmailService emailService)
    {
      this.userManager = userManager;
      this.httpContext = httpContext.HttpContext;
      this.emailService = emailService;
    }

    public async Task<IFormResult> HandleAsync(ForgotPasswordEditModel request)
    {
      var user = await userManager.FindByEmailAsync(request.Email);

      //Require a verified email address for password recovery?
      if (user != null)
      {
        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        var callbackUrl = BuildCallbackUrl(user.Email, code);
        await emailService.SendPasswordResetEmailAsync(user.Email, callbackUrl);
      }
      return FormResult.Success;
    }

    //TODO: Shit way to build callback url, needs to be refactored
    private string BuildCallbackUrl(string email, string passwordResetCode)
    {
      var scheme = "https";
      var host = httpContext.Request.Host.Host;
      var port = httpContext.Request.Host.Port ?? 80;

      var uriBuilder = new UriBuilder(scheme, host, port, @"/Account/ResetPassword");

      var queryBuilder = new QueryBuilder(new[]
      {
        new KeyValuePair<string, string>("email", $@"{email}"),
        new KeyValuePair<string, string>("code", $@"{passwordResetCode}"), 
      });

      uriBuilder.Query = queryBuilder.ToQueryString().ToString();

      return uriBuilder.Uri.AbsoluteUri;
    }
  }
}

