﻿using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.User.Models
{
  public class User : IdentityUser<Guid>, ITrackedPersistedEntity<Guid>
  {
    public User()
    {
  
    }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime LastLogin { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public UserAddress Address { get; set; }

    public bool IsNew => this.Id == Guid.Empty;
  }
}
