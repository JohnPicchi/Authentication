using System.Linq;
using Authentication.Core.Models.Contracts;
using Authentication.Core.ServiceContracts;
using Authentication.Database;
using Authentication.Domain.Account;
using Authentication.Domain.Account.Models;


namespace Authentication.Repositories
{
  public class AccountRepository : Repository<PresistenceModels.Account>, IAccountRepository
  {
    public AccountRepository(IApplicationSettings applicationSettings) : base(applicationSettings)
    {

    }

    public bool AccountExists(string accountId) => Query().Any(a => a.Id == accountId);

    public Account Add(Account account)
    {
      throw new System.NotImplementedException();
    }

    public Account Find(string accountId)
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
