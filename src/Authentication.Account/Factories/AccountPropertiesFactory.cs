using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using Authentication.Domain;

namespace Authentication.Account.Factories
{
  public interface IAccountPropertiesFactory : IFactory<AccountProperties>
  {
    
  }

  public class AccountPropertiesFactory : IAccountPropertiesFactory
  {
    private readonly AccountProperties.Factory accountPropertiesFactory;

    public AccountPropertiesFactory(AccountProperties.Factory accountPropertiesFactory)
    {
      this.accountPropertiesFactory = accountPropertiesFactory;
    }

    public AccountProperties Create()
    {
      return accountPropertiesFactory.Invoke();
    }
  }
}
