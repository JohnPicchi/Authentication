using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.Account.Models;

namespace Authentication.PresistenceModels
{
  public class AccountProperties : PersistedEntity<Guid>
  {
    /// <summary>
    /// The account who these properties
    /// belong to.
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// The foreign key of the Account who
    /// these properties belong to
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// Determines whether or not the user must reset their password
    /// </summary>
    public bool? ResetPassword { get; set; }

    /// <summary>
    /// Number of failed login attempts  before
    /// successfully logging in
    /// </summary>
    public int? FailedLoginAttempts { get; set; }

    /// <summary>
    /// The user's unique open connect id
    /// </summary>
    public Guid OpenConnectId { get; set; }

    /// <summary>
    /// Locks the account so the user cannot login
    /// </summary>
    public bool? Locked { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? LockExpiration { get; set; }

    /// <summary>
    /// The user has verified their email address
    /// </summary>
    public bool? Verified { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public MutliFactorAuthKind MutliFactorAuthKind { get; set; }

    /// <summary>
    /// The last date/time the user logged in
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// The last date/time the user logged in
    /// </summary>
    public DateTime? CurrentLogin { get; set; }
  }
}
