using System.Linq;
using Authentication.Core.ServiceContracts;
using Authentication.Domain.Account;
using Authentication.Domain.Account.Models;


namespace Authentication.Repositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly IRepository<PresistenceModels.Account> repository;

    public AccountRepository(IRepository<PresistenceModels.Account> repository)
    {
      this.repository = repository;
    }

    public bool UsernameExists(string username) => repository.Query().Any(a => a.Id == username);

    public Account Add(Account account)
    {
      throw new System.NotImplementedException();
    }

    public Account Find(string username)
    {
      throw new System.NotImplementedException();
    }

    public void Remove(Account account)
    {
      throw new System.NotImplementedException();
    }

    public void Remove(string username)
    {
      throw new System.NotImplementedException();
    }
  }
}
