using System;
using System.Linq;

namespace Authentication.Domain.Account.Models
{
  public class User
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => String.Join(" ", FirstName, LastName);

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
  }
}