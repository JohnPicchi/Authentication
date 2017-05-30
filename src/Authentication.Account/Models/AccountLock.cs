using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain;
using Autofac.Extras.DynamicProxy;

namespace Authentication.Account.Models
{
  public enum AccountLockKind
  {
    Temporary = 0,
    Permanent = 1
  }


  public class AccountLock : Entity<Guid>
  {
    private AccountLockKind kind;
    private string message;
    private DateTime? dateCreated;
    private DateTime? expirationDate;


    public AccountLock()
    {
      
    }

    public delegate AccountLock Factory();

    public virtual AccountLockKind Kind
    {
      get => kind;
      set => (kind, IsDirty) = (value, true);
    }

    public virtual string Message
    {
      get => message;
      set => (message, IsDirty) = (value, true);
    }

    public virtual DateTime? DateCreated
    {
      get => dateCreated;
      set => (dateCreated, IsDirty) = (value, true);
    }

    public virtual DateTime? ExpirationDate
    {
      get => expirationDate;
      set => (expirationDate, IsDirty) = (value, true);
    }

    public virtual bool IsValid => (Kind == AccountLockKind.Permanent) 
                           || (ExpirationDate ?? DateTime.UtcNow) > DateTime.UtcNow.AddSeconds(30);
  }
}
