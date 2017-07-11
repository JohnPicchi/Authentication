using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.RequestHandlers
{
  public class LoginRequestHandlerAsync : IRequestHandlerAsync<LoginEditModel, SignInResult>
  {
    private readonly SignInManager<User.Models.User> signInManager;

    public LoginRequestHandlerAsync(SignInManager<User.Models.User> signInManager)
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
