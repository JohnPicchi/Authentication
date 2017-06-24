using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.PersistenceModels
{
  public class UserLogin : IdentityUserLogin<Guid>
  {
    public Guid Id { get; set; }

  }
}
