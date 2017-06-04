using System;
using Authentication.Account.Models;

namespace Authentication.PresistenceModels.Models
{
  public class AccountToken : Entity<Guid>
  {
    /// <summary>
    /// The account who this token belongs to
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// The foreign key of the account who
    /// the token belongs to
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// The value of the token
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// The kind of token
    /// (eg: password reset, 2-factor auth etc...)
    /// </summary>
    public TokenKind Kind { get; set; }

    /// <summary>
    /// The date/time (UTC) the token was created
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// The date/time (UTC) the token expires
    /// </summary>
    public DateTime ExpirationDate { get; set; }
  }
}
