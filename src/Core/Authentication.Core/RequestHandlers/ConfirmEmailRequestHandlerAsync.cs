using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class ConfirmEmailRequestHandlerAsync : IRequestHandlerAsync<GenericResult>
  {
    private readonly IApplicationContext applicationContext;
    private readonly UserManager<User.Models.User> userManager;
    private readonly HttpContext httpContext;
    private readonly IEmailService emailService;

    public ConfirmEmailRequestHandlerAsync(
      IApplicationContext applicationContext,
      UserManager<User.Models.User> userManager,
      IHttpContextAccessor httpContext,
      IEmailService emailService)
    {
      this.applicationContext = applicationContext;
      this.userManager = userManager;
      this.httpContext = httpContext.HttpContext;
      this.emailService = emailService;
    }

    public async Task<GenericResult> HandleAsync()
    {
      var user = applicationContext.User;
      if (user != null)
      {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        var callbackUrl = BuildCallbackUrl(user.Id.ToString(), code);
        await emailService.SendEmailConfirmationEmailAsync(user.Email, callbackUrl);
      }
      return GenericResult.Success;
    }
   
    //TODO: Shit way to build callback url, needs to be refactored
    private string BuildCallbackUrl(string userId, string code)
    {
      var scheme = "https";
      var host = httpContext.Request.Host.Host;
      var port = httpContext.Request.Host.Port ?? 80;

      var uriBuilder = new UriBuilder(scheme, host, port, @"/Account/VerifyEmail");

      var queryBuilder = new QueryBuilder(new[]
      {
        new KeyValuePair<string, string>("userId", $@"{userId}"),
        new KeyValuePair<string, string>("code", $@"{code}"),
      });

      uriBuilder.Query = queryBuilder.ToQueryString().ToString();

      return uriBuilder.Uri.AbsoluteUri;
    }
  }
}