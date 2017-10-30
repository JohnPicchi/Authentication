using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers.FormHandlers.Account
{
  public class LoginRequestHandler : IRequestHandler<LoginEditModel, SignInResult>
  {
    private readonly SignInManager<User.Models.User> signInManager;

    public LoginRequestHandler(SignInManager<User.Models.User> signInManager)
    {
      this.signInManager = signInManager;
    }

    public async Task<SignInResult> HandleAsync(LoginEditModel request)
    {
      return await signInManager.PasswordSignInAsync(
        userName: request.Email, 
        password: request.Password,
        isPersistent: request.RememberLogin, 
        lockoutOnFailure: true);
    }
  }
}
