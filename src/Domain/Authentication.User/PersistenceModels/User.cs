using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.User.PersistenceModels
{
  public class User : IdentityUser<Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, UserLogin>
  {

  }
}
