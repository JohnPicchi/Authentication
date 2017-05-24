using System;
using System.Linq;
using Authentication.Account;
using Authentication.Account.Models;
using Authentication.Core.Models.Contracts;
using Authentication.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repositories
{
  public class AccountRepository : Repository<PresistenceModels.Account>, IAccountRepository
  {
    private readonly IMapper mapper;
    private readonly IAccountFactory accountFactory;

    public AccountRepository(IApplicationSettings applicationSettings, IMapper mapper, IAccountFactory accountFactory) : base(applicationSettings)
    {
      this.mapper = mapper;
      this.accountFactory = accountFactory;
    }

    public bool AccountExists(string username) => Query().Any(a => a.Username == username);

    public void Add(Account.Models.Account account)
    {
      var persistedAccount = mapper.Map<Account.Models.Account, PresistenceModels.Account>(account);
      base.Add(persistedAccount);
    }

    public Account.Models.Account Find(Guid accountId)
    {
      var persistedAccount = base.Find(accountId);
      return mapper.Map<PresistenceModels.Account, Account.Models.Account>(persistedAccount);
    }

    public Account.Models.Account Find(string username)
    {
      var persistedAccount = Query()
        .Include(a => a.Properties)
        .FirstOrDefault(a => a.Username == username);

      return mapper.Map(persistedAccount, accountFactory.Create());
    }

    public void Remove(Account.Models.Account account) => Remove(account.Id);

    public void Remove(Guid accountId) => base.Remove(new PresistenceModels.Account { Id = accountId});
  }
}