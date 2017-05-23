using System;
using System.Text;
using Authentication.Account;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Domain;
using Authentication.PresentationModels.EditModels;
using Authentication.Utilities.ExtensionMethods;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class RegisterEditModelFormResultRequestHandler : IFormResultRequestHandler<RegisterEditModel>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IAccountFactory accountFactory;

    public RegisterEditModelFormResultRequestHandler(IAccountRepository accountRepository, IAccountFactory accountFactory)
    {
      this.accountRepository = accountRepository;
      this.accountFactory = accountFactory;
    }

    public IFormResult Handle(RegisterEditModel registerEditModel)
    {
      var formResult = RegistrationIsValid(registerEditModel);

      if (formResult.Success)
      {
        var account = accountFactory.Create(registerEditModel.Email, registerEditModel.Password.Hash());
        accountRepository.Add(account);
      }
    

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