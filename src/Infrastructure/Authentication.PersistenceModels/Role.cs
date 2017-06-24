using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.PersistenceModels
{
  public class Role : IdentityRole<Guid, UserRole, RoleClaim>
  {
    
  }
}