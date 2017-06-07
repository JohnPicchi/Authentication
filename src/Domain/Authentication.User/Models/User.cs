using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain;

namespace Authentication.User.Models
{
  public class User : DomainEntity<Guid>
  {
    public User()
    {
      
    }

    public delegate User Factory();

    public virtual string FirstName { get; set; }

    public virtual string LastName { get; set; }

    public virtual string Email { get; set; }

    public virtual string PhoneNumber { get; set; }

    public string FullName => String.Join(" ", FirstName, LastName);
  }
}
