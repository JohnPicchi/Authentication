using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.PersistenceModels
{
  public class UserToken: IdentityUserToken<Guid>
  {
    public Guid Id { get; set; }
  }
}
