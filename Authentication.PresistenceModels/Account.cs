using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.PresistenceModels
{
  public class Account : PersistedEntity<Guid>
  {
    /// <summary>
    /// The account's username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// The user's hashed password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The account's properties
    /// </summary>
    public AccountProperties Properties { get; set; }

    /// <summary>
    /// The user who owns this account
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Locks the account so the user cannot login
    /// </summary>
    public bool? IsLocked { get; set; }

    /// <summary>
    /// The user has verified their email address
    /// </summary>
    public bool? IsVerified { get; set; }

    /// <summary>
    /// The tokens belonging to this account
    /// </summary>
    public List<AccountToken> Tokens { get; set; }

    /// <summary>
    /// The claims belonging to this account
    /// </summary>
    public List<Claim> Claims { get; set; }
  }
}
