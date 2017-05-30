using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using Authentication.Domain;

namespace Authentication.Account.Factories
{
  public interface IAccountLockFactory : IFactory<AccountLock>
  {
    
  }

  public class AccountLockFactory : IAccountLockFactory
  {
    private readonly AccountLock.Factory accountLockFactory;

    public AccountLockFactory(AccountLock.Factory accountLockFactory)
    {
      this.accountLockFactory = accountLockFactory;
    }
    public AccountLock Create()
    {
      return accountLockFactory.Invoke();
    }
  }
}
