using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using Authentication.Domain;

namespace Authentication.Account.Factories
{
  public interface IAccountClaimFactory : IFactory<AccountClaim>
  {
    
  }

  public class AccountClaimFactory : IAccountClaimFactory
  {
    private readonly AccountClaim.Factory accountClaimFactory;
  
    public AccountClaimFactory(AccountClaim.Factory accountClaimFactory)
    {
      this.accountClaimFactory = accountClaimFactory;
    }

    public AccountClaim Create()
    {
      return accountClaimFactory.Invoke();
    }
  }
}
