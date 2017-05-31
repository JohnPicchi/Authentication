using System;
using Authentication.Account;
using Authentication.Account.Models;
using Authentication.Account.Repositories;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class LoginEditModelFormResultRequestHandler : IFormResultRequestHandler<LoginEditModel>
  {
    private readonly IAccountRepository accountRepository;

    public LoginEditModelFormResultRequestHandler(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    public IFormResult Handle(LoginEditModel request)
    {
      var account = accountRepository.Find(request.Email);
      if (account == null)
        return FormResult.Fail("Incorrect username and/or password");

      var result = account.Authenticate(request.Password);
      if (result.Status == AuthenticationStatus.Success)
      {
        accountRepository.Update(account);
        //TODO: Do Identity server shit here via a request ???

        return FormResult.Ok;
      }

      if (result.Status == AuthenticationStatus.MultiFactor)
      {
        //TODO: Generate + send email/text with login token
        return FormResult.Ok;
      }

      if (result.Status == AuthenticationStatus.Fail)
        return FormResult.Fail(result.Message);

      return FormResult.Ok;
    }
  }
}
