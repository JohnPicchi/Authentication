using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Account.Models;

namespace Authentication.Account
{
  public interface IAccountRepository
  {
    Task<bool> AccountExistsAsync(string username);

    void Add(Models.Account account);

    Task AddAsync(Models.Account account);

    bool Update(Models.Account account);

    bool AddOrUpdate(Models.Account account);

    Models.Account Find(string username);

    Models.Account Find(Guid accountId);

    AccountProperties AccountProperties(Guid accountId);

    IList<AccountClaim> AccountClaims(Guid accountId);

    IList<AccountToken> AccountTokens(Guid accountId);

    IList<AccountLock> AccountLocks(Guid accountId);

    AccountToken AccountToken(Guid accountId, TokenKind tokenKind);

    void Remove(Models.Account account);

    void Remove(Guid accountId);
  }
}
