using System;
using Authentication.Domain;
using Autofac.Extras.DynamicProxy;

namespace Authentication.Account.Models
{
  public class AccountClaim : DomainEntity<Guid>
  {

    public AccountClaim()
    {
      
    }

    public delegate AccountClaim Factory();

    public virtual string Type { get; set; }

    public virtual string Value { get; set; }

    public virtual string ValueType { get; set; }

    public virtual string Issuer { get; set; }

  }
}
