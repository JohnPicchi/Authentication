using System;
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

  public class AccountLock : Entity<Guid>
  {
    public AccountLockKind Kind { get; set; }

    public string Message { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool IsValid => (Kind == AccountLockKind.Permanent) 
                           || (ExpirationDate ?? DateTime.UtcNow) > DateTime.UtcNow.AddSeconds(30);
  }
}
