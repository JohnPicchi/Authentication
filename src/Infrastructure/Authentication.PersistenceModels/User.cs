using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.PersistenceModels
{
  public class User : IdentityUser<Guid, UserClaim, UserRole, UserLogin>
  {

  }
}
