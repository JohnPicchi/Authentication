﻿using System;
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


  public class AccountLock : DomainEntity<Guid>
  {
    public AccountLock()
    {
      
    }

    public delegate AccountLock Factory();

    public virtual AccountLockKind Kind { get; set; }

    public virtual string Message { get; set; }

    public virtual DateTime? DateCreated { get; set; }

    public virtual DateTime? ExpirationDate { get; set; }

    public virtual bool IsValid => (Kind == AccountLockKind.Permanent) 
                           || (ExpirationDate ?? DateTime.UtcNow) > DateTime.UtcNow.AddSeconds(30);
  }
}