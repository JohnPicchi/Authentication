using System;
using System.Collections.Generic;
using Authentication.Account.Models;

namespace Authentication.Account
{
  public interface IAccountRepository
  {
    bool AccountExists(string accountId);

    void Add(Models.Account account);

    bool Update(Models.Account account);

    bool AddOrUpdate(Models.Account account);

    Models.Account Find(string username);

    Models.Account Find(Guid accountId);

    Properties AccountProperties(Guid accountId);

    IList<Token> AccountTokens(Guid accountId);

    Token AccountToken(Guid accountId, TokenKind tokenKind);

    void Remove(Models.Account account);

    void Remove(Guid accountId);
  }
}
