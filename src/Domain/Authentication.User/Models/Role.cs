using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.User.Models
{
  public class Role : IdentityRole<Guid>, ITrackedPersistedEntity<Guid>
  {
    public bool IsNew => this.Id == Guid.Empty;

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}
