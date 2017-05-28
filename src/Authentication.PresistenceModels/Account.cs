using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.PresistenceModels
{
  public class Account : TrackedEntity<Guid>
  {
    /// <summary>
    /// The user's username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// The user's hashed password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The user has verified their email address
    /// </summary>
    public bool? IsVerified { get; set; }

    /// <summary>
    /// The account's properties
    /// </summary>
    public AccountProperties Properties { get; set; }

    /// <summary>
    /// The user who owns this account
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// The tokens belonging to this account
    /// </summary>
    public List<AccountToken> Tokens { get; set; }

    /// <summary>
    /// The claims belonging to this account
    /// </summary>
    public List<AccountClaim> Claims { get; set; }

    /// <summary>
    /// The locks placed on the account
    /// </summary>
    public List<AccountLock> Locks { get; set; }
  }
}
