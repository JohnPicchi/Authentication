using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class ConfirmPhoneNumberFormHandler : IFormHandler<ConfirmPhoneNumberEditModel>
  {
    private readonly UserManager<User.Models.User> userManager;

    public ConfirmPhoneNumberFormHandler(
      UserManager<User.Models.User> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<IFormResult> HandleAsync(ConfirmPhoneNumberEditModel request)
    {
     // var user = applicationContext.User;
     // if (user != null)
     // {
     //   var result = await userManager.VerifyChangePhoneNumberTokenAsync(user, request.SecurityCode, user.PhoneNumber);
     //   if (result)
     //   {
     //     user.PhoneNumberConfirmed = true;
     //     return FormResult.Success;
     //   }
     //   return FormResult.Fail("Invalid confirmation code");
     // }
      return FormResult.Fail("Unable to confirm phone number due to an error");
    }
  }
}
