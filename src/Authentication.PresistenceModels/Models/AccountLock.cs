using System;
using Authentication.Account.Models;

namespace Authentication.PresistenceModels.Models
{
  public class AccountLock : TrackedEntity<Guid>
  {
    /// <summary>
    /// The account who 'owns' the lock
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// The Id of the account who 'owns' the lock
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// The kind of lock placed on the account (eg: Permanent, Temporary)
    /// </summary>
    public AccountLockKind Kind { get; set; }

    /// <summary>
    /// The reason why the account was locked
    /// </summary>
    public string Message { get; set; }


    /// <summary>
    /// If applicable, the date/time (in UTC) the lock expires
    /// </summary>
    public DateTime? ExpirationDate { get; set; }
  }
}
