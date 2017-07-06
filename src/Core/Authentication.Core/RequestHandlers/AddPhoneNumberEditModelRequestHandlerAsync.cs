using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Core.ServiceContracts;
using Authentication.PresentationModels.EditModels;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class AddPhoneNumberEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<AddPhoneNumberEditModel>
  {
    private readonly IApplicationSettings applicationSettings;
    private readonly UserManager<User.Models.User> userManager;
    private readonly ISmsService smsService;
    private readonly HttpContext httpContext;

    public AddPhoneNumberEditModelRequestHandlerAsync(
      IApplicationSettings applicationSettings,
      UserManager<User.Models.User> userManager,
      ISmsService smsService,
      IHttpContextAccessor httpContextAccessor)
    {
      this.applicationSettings = applicationSettings;
      this.userManager = userManager;
      this.smsService = smsService;
      this.httpContext = httpContextAccessor.HttpContext;
    }

    public async Task<IFormResult> HandleAsync(AddPhoneNumberEditModel request)
    {
      var user = await userManager.GetUserAsync(httpContext.User);

      if (user != null)
      {
        user.PhoneNumber = request.PhoneNumber;
        user.PhoneNumberConfirmed = false;

        var code = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
        var subject = @"bitbyte.io - security code";
        var message = $"Your security code is: {code}";

        var result = await smsService.SendSmsMessageAsync(request.PhoneNumber, subject, message);

        if (result != null && result.MessageId.HasValue())
          return FormResult.Ok;
      }
      return FormResult.Fail("Unable to send sercurity code");
    }
  }
}
