using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Core.RequestHandlers
{
  public class LoginRequestHandlerAsync : IRequestHandlerAsync<AccountLoginRequestAsync, Account.Models.Account>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IClaimsService claimsService;

    public LoginRequestHandlerAsync(IAccountRepository accountRepository, IClaimsService claimsService)
    {
      this.accountRepository = accountRepository;
      this.claimsService = claimsService;
    }

    public async Task<Account.Models.Account> HandleAsync(AccountLoginRequestAsync request)
    {
      var account = await accountRepository.FindAsync(request.Form.Email);

      if (account != null)
      {
        var authenticationResult = account.Authenticate(request.Form.Password);
        if (authenticationResult.Status == AuthenticationStatus.Sucess)
        {
          var authenticationProperties = request.Form.RememberLogin
            ? new AuthenticationProperties { IsPersistent = true, IssuedUtc = DateTime.UtcNow, ExpiresUtc = DateTime.UtcNow.AddMonths(1) }
            : null;

          var openConnectId = account.Properties.OpenConnectId.ToString();
          var principal = IdentityServerPrincipal.Create(openConnectId, account.Username);

          //principal.Identities.First().AddClaims(new List<Claim>
          //{
          //  new Claim(JwtClaimTypes.Role, "Administrator", null, "http://localhost:5000")
          //});
          
          await request.AuthenticationManager.SignInAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme, principal, authenticationProperties);
        }

        else if (authenticationResult.Status == AuthenticationStatus.MultiFactor)
        {
          //TODO: Generate & send email/text with login token   
        }
        accountRepository.Update(account);
      }

      return account;
    }
  }
}
