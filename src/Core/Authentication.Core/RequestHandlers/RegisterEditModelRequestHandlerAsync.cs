using System.Linq;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class RegisterEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<RegisterEditModel>
  {
    public const string ACCOUNT_REGISTRATION_ERROR = "Unable to register account due to an error.";

    private readonly UserManager<User.Models.User> userManager;

    public RegisterEditModelRequestHandlerAsync(UserManager<User.Models.User> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<IFormResult> HandleAsync(RegisterEditModel registerEditModel)
    {
      var user = new User.Models.User
      {
        UserName = registerEditModel.Email,
        Email = registerEditModel.Email,
      };
      var result = await userManager.CreateAsync(user, registerEditModel.Password);

      return result.Succeeded
        ? FormResult.Ok
        : FormResult.Fail(result.Errors.FirstOrDefault()?.Description ?? ACCOUNT_REGISTRATION_ERROR);
    }
  }
}