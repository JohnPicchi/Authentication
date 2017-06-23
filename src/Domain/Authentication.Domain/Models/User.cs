using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Domain.Models
{
  public class User : IdentityUser<Guid, UserClaim, UserRole, UserLogin>
  {

  }
}
