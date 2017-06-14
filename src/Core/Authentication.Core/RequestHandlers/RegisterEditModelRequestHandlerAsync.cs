using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;

namespace Authentication.Core.RequestHandlers
{
  public class RegisterEditModelRequestHandlerAsync : IFormResultRequestHandlerAsync<RegisterEditModel>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IAccountFactory accountFactory;

    public RegisterEditModelRequestHandlerAsync(IAccountRepository accountRepository, IAccountFactory accountFactory)
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