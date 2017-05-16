using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.PresistenceModels
{
  public class Account : PersistedEntity<string>
  {

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
    /// The tokens belonging to this account
    /// </summary>
    public List<AccountToken> Tokens { get; set; }

    /// <summary>
    /// The claims belonging to this account
    /// </summary>
    public List<Claim> Claims { get; set; }

  }
}
