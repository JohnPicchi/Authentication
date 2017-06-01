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
    private const string INCORRECT_LOGIN = "Incorrect username and/or password";

    public LoginEditModelFormResultRequestHandler(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    public (bool Success, string Message) Handle(LoginEditModel request)
    {
      var account = accountRepository.Find(request.Email);
      if (account == null)
        return (Success: false, Message: INCORRECT_LOGIN);

      var result = account.Authenticate(request.Password);
      if (result.Status == AuthenticationStatus.Sucess)
      {
        accountRepository.Update(account);
        //TODO: Do Identity server shit here via a request ???

        return (Success: true, Message: null);
      }

      if (result.Status == AuthenticationStatus.MultiFactor)
      {
        //TODO: Generate & send email/text with login token
        return (Success: true, Message: null);
      }

      return (Success: false, Message: result.Message ?? INCORRECT_LOGIN);
    }
  }
}
