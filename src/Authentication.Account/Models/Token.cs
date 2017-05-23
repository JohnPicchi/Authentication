using System;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public enum TokenKind
  {
    PasswordReset = 0,
    MultiFactorAuth = 1
  }

  public class Token : Entity<Guid>
  {
    public TokenKind Kind { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime ExpirationTime { get; set; }

    public string Value { get; set; }
  }
}
