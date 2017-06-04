using System;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Account.Models;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class RegisterEditModelFormResultRequestHandlerAsync : IFormResultRequestHandlerAsync<RegisterEditModel>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IAccountFactory accountFactory;

    public RegisterEditModelFormResultRequestHandlerAsync(IAccountRepository accountRepository, IAccountFactory accountFactory)
    {
      this.accountRepository = accountRepository;
      this.accountFactory = accountFactory;
    }

    public async Task<IFormResult> HandleAsync(RegisterEditModel registerEditModel)
    {
      var account = accountFactory.Create(registerEditModel.Email, registerEditModel.Password);
      await accountRepository.AddAsync(account);
      return FormResult.Ok;
    }
  }
}