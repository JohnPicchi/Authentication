using System;
using Authentication.Account;
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

    public IFormResult Handle(LoginEditModel request)
    {
      var account = accountRepository.Find(request.Email);
      if (account == null)
        return FormResult.Fail(INCORRECT_LOGIN);

      var result = account.Authenticate(request.Password);
      if (result.Status == AuthenticationStatus.Sucess)
      {
        accountRepository.Update(account);
        //TODO: Do Identity server shit here via a request ???

        return FormResult.Ok;
      }

      if (result.Status == AuthenticationStatus.MultiFactor)
      {
        //TODO: Generate & send email/text with login token
        return FormResult.Ok;
      }

      return FormResult.Fail(result.ErrorMessage ?? INCORRECT_LOGIN);
    }
  }
}
