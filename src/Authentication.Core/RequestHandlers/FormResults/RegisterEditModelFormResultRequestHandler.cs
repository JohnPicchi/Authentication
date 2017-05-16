using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Core.ServiceContracts;
using Authentication.Domain.Account;
using Authentication.Domain.Account.Models;
using Authentication.PresentationModels.EditModels;
using Authentication.Utilities.ExtensionMethods;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class RegisterEditModelFormResultRequestHandler : IFormResultRequestHandler<RegisterEditModel>
  {
    private readonly IAccountRepository accountRepository;

    public RegisterEditModelFormResultRequestHandler(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    public IFormResult Handle(RegisterEditModel registerEditModel)
    {
      if (RegistrationIsValid(registerEditModel))
      {
        var account = new Account
        {
          Id = registerEditModel.Email,
          Password = registerEditModel.Password,
          User = new User
          {
            FirstName = registerEditModel.FirstName,
            LastName = registerEditModel.LastName,
            Email = registerEditModel.Email,
          }
        };

        accountRepository.Add(account);

        return FormResult.Ok;
      }

      return FormResult.Fail("Registration failure. An error was encountered while registering the account.");
    }

    private bool RegistrationIsValid(RegisterEditModel registerEditModel)
    {
      if (!registerEditModel.Email.HasValue() && registerEditModel.Password.HasValue())
        if (!accountRepository.UsernameExists(registerEditModel.Email))
          return true;

      return false;
    }
  }
}
