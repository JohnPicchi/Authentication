using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.User.Models
{
  public class UserLogin : IdentityUserLogin<Guid>
  {
  }
}