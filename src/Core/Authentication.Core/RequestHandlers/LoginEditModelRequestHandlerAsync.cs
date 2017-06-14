using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using IdentityServer4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;

namespace Authentication.Core.RequestHandlers
{
  public class LoginEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<LoginEditModel>
  {
    private readonly IAccountRepository accountRepository;
    private readonly AuthenticationManager authenticationManager;

    public LoginEditModelRequestHandlerAsync(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
    {
      this.accountRepository = accountRepository;
      this.authenticationManager = httpContextAccessor.HttpContext.Authentication;
    }

    public async Task<IFormResult> HandleAsync(LoginEditModel request)
    {
      var account = await accountRepository.FindAsync(request.Email);

      IFormResult formResult = null;

      if (account != null)
      {
        var authenticationResult = account.Authenticate(request.Password);

        if (authenticationResult.Status == AuthenticationStatus.Sucess)
        {
          await Login(request, account);
          formResult = FormResult.Ok;
        }
        else if (authenticationResult.Status == AuthenticationStatus.MultiFactor)
        {
          await MultiFactorLogin(account);
          formResult = FormResult.Ok;
        }
        else
          formResult = FormResult.Fail(authenticationResult.ErrorMessage ?? Account.Models.Account.INCORRECT_LOGIN);

        accountRepository.Update(account);
      }

      return formResult ?? FormResult.Fail(Account.Models.Account.INCORRECT_LOGIN);
    }

    //Log the user in
    private async Task Login(LoginEditModel request, Account.Models.Account account)
    {
      var authenticationProperties = request.RememberLogin
        ? new AuthenticationProperties { IsPersistent = true, IssuedUtc = DateTime.UtcNow, ExpiresUtc = DateTime.UtcNow.AddMonths(1) }
        : null;

      var openConnectId = account.Properties.OpenConnectId.ToString();
      var principal = IdentityServerPrincipal.Create(openConnectId, account.Username);

      await authenticationManager.SignInAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme, principal, authenticationProperties);
    }


    private async Task MultiFactorLogin(Account.Models.Account account)
    {
      
    }
  }
}
