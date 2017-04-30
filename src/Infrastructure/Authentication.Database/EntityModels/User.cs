using System;
using System.Collections.Generic;

namespace Authentication.Database.EntityModels
{
  public class User : Entity<Guid>
  {
    /// <summary>
    /// The user's firstname
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// The user's lastname
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The user's email address. 
    /// Email address is also used for username
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The user's hashed password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The user's unique open connect id
    /// </summary>
    public Guid OpenConnectId { get; set; }

    /// <summary>
    /// The last date/time the user logged in
    /// </summary>
    public DateTime? LastLoginDate { get; set; }

    /// <summary>
    /// Number of failed login attempts  before
    /// successfully logging in
    /// </summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>
    /// Locks the account so the user cannot login
    /// </summary>
    public bool LockAccount { get; set; }

    /// <summary>
    /// Determines whether or not the user must reset their password
    /// </summary>
    public bool ResetPassword { get; set; }

    /// <summary>
    /// The user has verified their email address
    /// </summary>
    public bool VerifiedEmail { get; set; }

    /// <summary>
    /// The user's identity claims
    /// </summary>
    public List<Database.EntityModels.Claim> Claims { get; set; }
  }
}