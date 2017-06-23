using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Domain.Models
{
  public class UserRole : IdentityUserRole<Guid>
  {
    public Guid Id { get; set; }
  }
}
