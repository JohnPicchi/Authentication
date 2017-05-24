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
      var account = accountFactory.Create(registerEditModel.Email, registerEditModel.Password);
      accountRepository.Add(account);

      return FormResult.Ok;
    }
  }
}