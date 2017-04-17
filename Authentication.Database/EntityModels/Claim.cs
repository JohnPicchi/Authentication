using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Database.EntityModels
{
  public class Claim : Entity<Guid>
  {
    /// <summary>
    /// The user who owns claim
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Foreign key of the user
    /// who owns the claim
    /// </summary>
    public Guid UserId { get; set; }

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
  }
}
