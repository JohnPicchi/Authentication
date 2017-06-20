using System;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public enum TokenKind
  {
    MultiFactorAuth = 0,
    PasswordReset = 1,
    EmailVerification = 2
  }

  public class Token : DomainEntity<Guid>
  {
    public virtual TokenKind Kind { get; set; }

    public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public virtual DateTime ExpirationDate { get; set; }

    public virtual string Value { get; set; }

    public virtual bool IsExpired => ExpirationDate < DateTime.UtcNow;

    public virtual bool IsValid => !IsExpired
                                   && DateCreated <= DateTime.UtcNow
                                   && DateCreated < ExpirationDate
                                   && !String.IsNullOrEmpty(Value)
                                   && Value != String.Empty;
  }
}
