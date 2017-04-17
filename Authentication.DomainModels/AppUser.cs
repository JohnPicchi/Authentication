using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.DomainModels
{
  public class AppUser
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public DateTime? LastLogin { get; set; }
  }
}
