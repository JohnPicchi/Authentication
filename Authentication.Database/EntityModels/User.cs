using System;
using System.Collections.Generic;
using System.Text;

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
    /// The user's username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The user's hashed password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The last date/time the user logged in
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// Number of failed login attempts 
    /// </summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>
    /// Locks the account so the user cannot login
    /// </summary>
    public bool LockAccount { get; set; }

    /// <summary>
    /// The user's identity claims
    /// </summary>
    public List<Claim> Claims { get; set; }

    public bool ResetPassword { get; set; }
  }
}
