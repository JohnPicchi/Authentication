using System;
using Authentication.Account;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Authentication.Utilities.ExtensionMethods;

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
        return FormResult.Fail("Incorrect username or password");

      var isValid = account.Authenticate(request.Password);
     // if (!isValid)
     //   account.Properties.FailedLoginAttempts += 1;

      accountRepository.Update(account);



      return FormResult.Ok;
    }
  }
}
