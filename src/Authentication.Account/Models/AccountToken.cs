using System;
using Authentication.Domain;
using Autofac.Extras.DynamicProxy;

namespace Authentication.Account.Models
{
  public enum TokenKind
  {
    PasswordReset = 0,
    MultiFactorAuth = 1
  }

  public class AccountToken : Entity<Guid>
  {
    private TokenKind kind;
    private DateTime dateCreated;
    private DateTime expirationDate;
    private string value;

    public AccountToken()
    {
      
    }

    public delegate AccountToken Factory();

    public virtual TokenKind Kind
    {
      get => kind;
      set => (kind, IsDirty) = (value, true);
    }

    public virtual DateTime DateCreated
    {
      get => dateCreated;
      set => (dateCreated, IsDirty) = (value, true);
    }

    public virtual DateTime ExpirationDate
    {
      get => expirationDate;
      set => (expirationDate, IsDirty) = (value, true);
    }

    public virtual string Value
    {
      get => value;
      set => (this.value, IsDirty) = (value, true);
    }

    public virtual bool IsExpired => ExpirationDate < DateTime.UtcNow;
  }
}
