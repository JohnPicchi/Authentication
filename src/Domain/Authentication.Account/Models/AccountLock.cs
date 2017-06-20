﻿using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public enum AccountLockKind
  {
    Temporary = 0,
    Permanent = 1
  }


  public class AccountLock : DomainEntity<Guid>
  {
    public virtual AccountLockKind Kind { get; set; }

    public virtual string Message { get; set; }

    public virtual DateTime? DateCreated { get; set; } = DateTime.UtcNow;

    public virtual DateTime? ExpirationDate { get; set; }

    public virtual bool IsValid => (Kind == AccountLockKind.Permanent) 
                                   || (ExpirationDate ?? DateTime.UtcNow) > DateTime.UtcNow.AddSeconds(30);

    public static AccountLock MaxLoginAttempts => new AccountLock
    {
      Kind = AccountLockKind.Temporary,
      DateCreated = DateTime.UtcNow,
      ExpirationDate = DateTime.UtcNow.AddMinutes(15),
      Message = "Account has been temporarily locked due to excessive failed login attempts."
    };
  }
}
