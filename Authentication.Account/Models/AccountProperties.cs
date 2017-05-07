using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Account.Models
{
  public class AccountProperties
  {
    public int FailedLoginAttempts { get; set; }

    public DateTime? CurrentLogin { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool PasswordResetRequired { get; set; }

    public List<string> PasswordHistory { get; set; }

    public Guid OpenConnectId { get; set; }
  }
}
