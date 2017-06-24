using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.User.PersistenceModels
{
  //public abstract class User<TId> : IdentityUse<>
  public class User : IdentityUser<Guid, UserClaim, UserRole, UserLogin>
  {
  }
}
