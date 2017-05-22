﻿using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Domain.Account;
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
      var test = account.Password.VerifyHash(request.Password);
      

      return FormResult.Ok;
    }
  }
}
