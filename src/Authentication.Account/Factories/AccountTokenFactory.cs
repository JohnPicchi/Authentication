using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using Authentication.Domain;

namespace Authentication.Account.Factories
{
  public interface IAccountTokenFactory : IFactory<AccountToken>
  {
    
  }

  public class AccountTokenFactory : IAccountTokenFactory
  {
    private readonly AccountToken.Factory accountTokenFactory;

    public AccountTokenFactory(AccountToken.Factory accountTokenFactory)
    {
      this.accountTokenFactory = accountTokenFactory;
    }

    public AccountToken Create()
    {
      return accountTokenFactory.Invoke();
    }
  }
}
