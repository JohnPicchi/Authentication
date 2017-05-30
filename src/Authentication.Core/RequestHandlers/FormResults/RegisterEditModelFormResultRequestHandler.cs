using System;
using System.Text;
using Authentication.Account;
using Authentication.Account.Factories;
using Authentication.Account.Models;
using Authentication.Account.Repositories;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.Domain;
using Authentication.PresentationModels.EditModels;

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
      var account = accountFactory.Create(registerEditModel.Email, registerEditModel.Password);
      account.AddLock(new AccountLock{Message = "TEST"});
      accountRepository.Add(account);

      return FormResult.Ok;
    }
  }
}