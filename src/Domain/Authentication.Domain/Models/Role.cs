﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Domain.Models
{
  public class Role : IdentityRole<Guid, UserRole, RoleClaim>
  {
    
  }
}
