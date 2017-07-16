using System.Linq;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers
{
  public class AddUserFormHandlerAsync : IFormHandlerAsync<AddUserEditModel>
  {
    public const string ACCOUNT_REGISTRATION_ERROR = "Unable to register account due to an error.";

    private readonly UserManager<User.Models.User> userManager;

    public AddUserFormHandlerAsync(UserManager<User.Models.User> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<IFormResult> HandleAsync(AddUserEditModel registerEditModel)
    {
      var user = new User.Models.User
      {
        UserName = registerEditModel.Email,
        Email = registerEditModel.Email,
      };
      var result = await userManager.CreateAsync(user, registerEditModel.Password);

      return result.Succeeded
        ? FormResult.Success
        : FormResult.Fail(result.Errors.FirstOrDefault()?.Description ?? ACCOUNT_REGISTRATION_ERROR);
    }
  }
}