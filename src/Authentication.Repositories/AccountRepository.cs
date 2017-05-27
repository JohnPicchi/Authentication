using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Account;
using Authentication.Account.Models;
using Authentication.Core.Models.Contracts;
using Authentication.Database;
using Authentication.Database.Contexts;
using Authentication.Utilities.ExtensionMethods;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repositories
{
  public class AccountRepository : Repository<PresistenceModels.Account>, IAccountRepository
  {
    private readonly IMapper mapper;
    private readonly IAccountFactory accountFactory;

    public AccountRepository(
      DatabaseContext databaseContext, 
      IMapper mapper, 
      IAccountFactory accountFactory) : base(databaseContext)
    {
      this.mapper = mapper;
      this.accountFactory = accountFactory;
    }

    public bool AccountExists(string username)
    {
      return username.HasValue() && Query().Any(a => a.Username == username);
    }

    public void Add(Account.Models.Account account)
    {
      if (account != null)
      {
        var persistedAccount = mapper.Map<Account.Models.Account, PresistenceModels.Account>(account);
        account.Id = base.Add(persistedAccount).Id;
      }
    }

    public bool AddOrUpdate(Account.Models.Account account)
    {
      var result = false;

      if (account != null && account.IsNew)
      {
        Add(account);
        result = !account.IsNew;
      }
      else if (account != null)
        result = Update(account);

      return result;
    }

    public bool Update(Account.Models.Account account)
    {
      if (account != null && !account.IsNew)
      {
        var persistedAccount = base.Find(account.Id);

        //If the domain entity is not new, and for some reason
        // doesn't exist in the db.....
        if (persistedAccount == null)
        {
          persistedAccount = new PresistenceModels.Account();
          mapper.Map(account, persistedAccount);

          //Since the domain entity is not new (it has an Id), it needs 
          //to be attached to the change tracker AFTER mapping
          base.Add(persistedAccount);   
        }
        else
          mapper.Map(account, persistedAccount);
        base.Save();
        return true;
      }
      return false;
    }

    public Account.Models.Account Find(Guid accountId)
    {
      var persistedAccount = base.Find(accountId);

      return persistedAccount == null 
        ? null
        : mapper.Map(persistedAccount, accountFactory.Create());
    }

    public Account.Models.Account Find(string username)
    {
      var persistedAccount = username.HasValue()
        ? Query().Where(a => a.Username == username)
          .Include(a => a.Properties)
          .SingleOrDefault()
        : null;

      return persistedAccount == null
        ? null
        : mapper.Map(persistedAccount, accountFactory.Create());
    }

    public Properties AccountProperties(Guid accountId)
    {
      var persistedProperties = Query()
        .Select(a => a.Properties)
        .SingleOrDefault(a => a.AccountId == accountId);

      return persistedProperties == null 
        ? null
        : mapper.Map(persistedProperties, new Properties());
    }

    public IList<Token> AccountTokens(Guid accountId)
    {
      var persistedTokens = Query()
        .Where(a => a.Id == accountId)
        .SelectMany(a => a.Tokens)
        .Where(a => a.AccountId == accountId)
        .ToList();

      return mapper.Map(persistedTokens, new List<Token>());
    }

    public Token AccountToken(Guid accountId, TokenKind tokenKind)
    {
      var persistedTokens = Query()
        .Where(a => a.Id == accountId)
        .SelectMany(a => a.Tokens)
        .FirstOrDefault(a => a.AccountId == accountId && a.Kind == tokenKind);

      return persistedTokens == null
        ? null
        : mapper.Map(persistedTokens, new Token());
    }

    public void Remove(Account.Models.Account account)
    {
      if(account != null)
        Remove(account.Id);
    }

    public void Remove(Guid accountId) => base.Remove(new PresistenceModels.Account { Id = accountId});
  }
}