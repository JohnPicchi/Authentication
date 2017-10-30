using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Core.ServiceContracts;
using Authentication.PresentationModels.Account.EditModels;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class AddPhoneNumberFormHandler : IFormHandler<AddPhoneNumberEditModel>
  {
    private readonly UserManager<User.Models.User> userManager;
    private readonly ISmsService smsService;

    public AddPhoneNumberFormHandler(
      UserManager<User.Models.User> userManager,
      ISmsService smsService)
    {
      this.userManager = userManager;
      this.smsService = smsService;
    }

    public async Task<IFormResult> HandleAsync(AddPhoneNumberEditModel request)
    {
      //var user = applicationContext.User;
      //if (user != null)
      //{
      //  user.PhoneNumber = request.PhoneNumber;
      //  user.PhoneNumberConfirmed = false;
      //
      //  var code = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
      //  var subject = @"bitbyte.io - security code";
      //  var message = $"Your security code is: {code}";
      //
      //  var result = await smsService.SendSmsMessageAsync(request.PhoneNumber, subject, message);
      //
      //  if (result != null && result.MessageId.HasValue())
      //    return FormResult.Success;
      //}
      return FormResult.Fail("Unable to send sercurity code");
    }
  }
}
