using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;

namespace Authentication.PresistenceModels
{
  public class AccountProperties : TrackedEntity<Guid>
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
    public Guid AccountId { get; set; }

    /// <summary>
    /// Determines whether or not the user must reset their password
    /// </summary>
    public bool? PasswordResetRequired { get; set; }

    /// <summary>
    /// Number of failed login attempts  before
    /// successfully logging in
    /// </summary>
    public int? FailedLoginAttempts { get; set; }

    /// <summary>
    /// The user's unique open connect id
    /// </summary>
    public Guid? OpenConnectId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public MutliFactorAuthKind MutliFactorAuthKind { get; set; }

    /// <summary>
    /// The last date/time (in UTC) the user logged in
    /// </summary>
    public DateTime? LastLoginDateTime { get; set; }

    /// <summary>
    /// The last date/time (in UTC) the user logged in
    /// </summary>
    public DateTime? CurrentLoginDateTime { get; set; }
  }
}
