using System;

namespace Authentication.PresistenceModels
{
  public class User : PersistedEntity<Guid>
  {
    /// <summary>
    /// The account of this user
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// The foreign key of the Account for
    /// who this user belongs to
    /// </summary>
    public Guid AccountId { get; set; }

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
    /// The user's phone number
    /// </summary>
    public string PhoneNumber { get; set; }
  }
}