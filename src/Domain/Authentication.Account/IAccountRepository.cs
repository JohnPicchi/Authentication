using System;
using System.Collections.Generic;
using System.Security.Claims;
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

    Task<Models.Account> FindAsync(string username);

    Models.Account Find(Guid accountId);

    Models.Account Find(String usernane);

    AccountProperties AccountProperties(Guid accountId);

    IList<Claim> AccountClaims(Guid accountId);

    IList<Token> AccountTokens(Guid accountId);

    IList<AccountLock> AccountLocks(Guid accountId);

    Token AccountToken(Guid accountId, TokenKind tokenKind);

    void Remove(Models.Account account);

    void Remove(Guid accountId);
  }
}
