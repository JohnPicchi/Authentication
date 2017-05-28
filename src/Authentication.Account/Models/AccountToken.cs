using System;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public enum TokenKind
  {
    PasswordReset = 0,
    MultiFactorAuth = 1
  }

  public class AccountToken : Entity<Guid>
  {
    public TokenKind Kind { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string Value { get; set; }

    public bool IsExpired => ExpirationDate < DateTime.UtcNow;
  }
}
