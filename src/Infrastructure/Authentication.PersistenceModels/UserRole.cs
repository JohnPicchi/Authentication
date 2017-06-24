using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.PersistenceModels
{
  public class UserRole : IdentityUserRole<Guid>
  {
    public Guid Id { get; set; }
  }
}
