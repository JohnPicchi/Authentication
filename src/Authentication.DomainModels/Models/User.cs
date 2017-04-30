using System;
using Authentication.Domain.ModelContracts;

namespace Authentication.Domain.Models
{
  public class User : IUser
  {
    public string UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public Guid OpenConnectId { get; set; }

    public DateTime? LastLogin { get; set; }
  }
}
