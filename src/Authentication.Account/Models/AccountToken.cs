using System;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public enum TokenKind
  {
    PasswordReset = 0,
    MultiFactorAuth = 1,
    EmailVerification = 2
  }

  public class AccountToken : DomainEntity<Guid>
  {
    public AccountToken()
    {
      
    }

    public delegate AccountToken Factory();

    public virtual TokenKind Kind { get; set; }

    public virtual DateTime DateCreated { get; set; }

    public virtual DateTime ExpirationDate { get; set; }

    public virtual string Value { get; set; }

    public virtual bool IsExpired => ExpirationDate < DateTime.UtcNow;
  }
}
