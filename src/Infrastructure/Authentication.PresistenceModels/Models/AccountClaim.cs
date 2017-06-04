using System;

namespace Authentication.PresistenceModels.Models
{
  public class AccountClaim : TrackedEntity<Guid>
  {
    /// <summary>
    /// The account who owns this claim
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    ///  The foreign key of the account
    /// who owns this claim
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// The type of claim
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// The value of the claim
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// The type of the value (boolean, string, etc..)
    /// </summary>
    public string ValueType { get; set; }

    /// <summary>
    /// The authority who issued this claim
    /// </summary>
    public string Issuer { get; set; }
  }
}
