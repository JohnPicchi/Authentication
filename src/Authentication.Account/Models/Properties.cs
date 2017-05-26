using System;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public enum MutliFactorAuthKind
  {
    None = 0,
    Email = 1,
    Sms = 2
  }

  public class Properties : Entity<Guid>
  {
    public int? FailedLoginAttempts { get; set; }

    public DateTime? CurrentLogin { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool ResetPassword { get; set; }

    public bool Locked { get; set; }

    public DateTime? LockExpiration { get; set; }

    public bool Verified { get; set; }

    public Guid OpenConnectId { get; set; }

    public MutliFactorAuthKind MultiFactorAuthKind { get; set; }
  }
}
