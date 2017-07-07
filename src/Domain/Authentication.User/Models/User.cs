using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.User.Models
{
  public class User : IdentityUser<Guid>
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public UserAddress Address { get; set; }
  }
}
