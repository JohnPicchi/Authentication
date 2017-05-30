using System;
using Authentication.Domain;
using Autofac.Extras.DynamicProxy;

namespace Authentication.Account.Models
{
  public class AccountClaim : Entity<Guid>
  {
    private string type;
    private string value;
    private string valueType;
    private string issuer;

    public AccountClaim()
    {
      
    }

    public delegate AccountClaim Factory();

    public virtual string Type
    {
      get => type;
      set => (type, IsDirty) = (value, true);
    }

    public virtual string Value
    {
      get => value;
      set => (this.value, IsDirty) = (value, true);
    }

    public virtual string ValueType
    {
      get => valueType;
      set => (valueType, IsDirty) = (value, true);
    }

    public virtual string Issuer
    {
      get => issuer;
      set => (issuer, IsDirty) = (value, true);
    }
  }
}
