using System;
using System.Text;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
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
      var formResult = RegistrationIsValid(registerEditModel);

      if (formResult.Success)
        accountRepository.Add(new Account
        {
          Id = registerEditModel.Email,
          Password = registerEditModel.Password.Hash()
        });

      return formResult;
    }

    private IFormResult RegistrationIsValid(RegisterEditModel registerEditModel)
    {
      var formResult = new FormResult{ Success = true };

      if (!registerEditModel.Email.HasValue())
      {
        formResult.Success = false;
        formResult.ErrorMessages.Add("Email is required");
      }

      if (!registerEditModel.Password.HasValue())
      {
        formResult.Success = false;
        formResult.ErrorMessages.Add("Password is required");
      }

      if (!registerEditModel.ConfirmPassword.HasValue())
      {
        formResult.Success = false;
        formResult.ErrorMessages.Add("Confirm password is required");
      }

      if (registerEditModel.Password != registerEditModel.ConfirmPassword)
      {
        formResult.Success = false;
        formResult.ErrorMessages.Add("Passwords do not match");
      }

      return formResult;
    }
  }
}