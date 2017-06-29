using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class LoginEditModelRequestHandlerAsync : IRequestHandlerAsync<LoginEditModel, SignInResult>
  {
    private readonly SignInManager<User.Models.User> signInManager;

    public LoginEditModelRequestHandlerAsync(SignInManager<User.Models.User> signInManager)
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
