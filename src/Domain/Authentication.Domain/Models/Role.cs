using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Domain.Models
{
  public class Role : IdentityRole<Guid>
  {
  }
}
