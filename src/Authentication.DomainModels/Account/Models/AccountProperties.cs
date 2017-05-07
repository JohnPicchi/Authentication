using System;
using System.Collections.Generic;

namespace Authentication.Domain.Account.Models
{
  public class AccountProperties
  {
    public int FailedLoginAttempts { get; set; }

    public DateTime? CurrentLogin { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool ResetPassword { get; set; }

    public List<string> PasswordHistory { get; set; }

    public Guid OpenConnectId { get; set; }

    public int MultiFactorAuthKind { get; set; }
  }
}
