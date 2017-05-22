using System.Linq;
using Authentication.Core.Models.Contracts;
using Authentication.Database;
using Authentication.Domain.Account;
using Authentication.Domain.Account.Models;
using AutoMapper;


namespace Authentication.Repositories
{
  public class AccountRepository : Repository<PresistenceModels.Account>, IAccountRepository
  {
    private readonly IMapper mapper;

    public AccountRepository(IApplicationSettings applicationSettings, IMapper mapper) : base(applicationSettings)
    {
      this.mapper = mapper;
    }

    public bool AccountExists(string accountId) => Query().Any(a => a.Id == accountId);

    public void Add(Account account)
    {
      var persistedAccount = mapper.Map<Account, PresistenceModels.Account>(account);
      base.Add(persistedAccount);
    }

    public Account Find(string accountId)
    {
      var persistedAccount = base.Find(accountId);
      return  mapper.Map<PresistenceModels.Account, Account>(persistedAccount);
    }

    public void Remove(Account account) => Remove(account.Id);

    public void Remove(string accountId) => base.Remove(new PresistenceModels.Account { Id = accountId });
  }
}