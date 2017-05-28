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

  public class AccountProperties : Entity<Guid>
  {
    public AccountProperties()
    {
      

    }

    public int FailedLoginAttempts { get; set; }

    public void ResetFailedLoginAttempts() => FailedLoginAttempts = 0;

    public DateTime? CurrentLoginDateTime { get; private set; }

    public DateTime? LastLoginDateTime { get; private set; }

    public bool UpdatedLoginTimes { get; private set; }

    public void UpdateLoginTimes()
    {
      if (!UpdatedLoginTimes)
      {
        LastLoginDateTime = CurrentLoginDateTime ?? DateTime.UtcNow;
        CurrentLoginDateTime = DateTime.UtcNow;
      }
      UpdatedLoginTimes = true;
    }

    public bool PasswordResetRequired { get; set; }

    public Guid OpenConnectId { get; private set; }

    public MutliFactorAuthKind MultiFactorAuthKind { get; set; }

    public bool HasMultiFactorAuth => MultiFactorAuthKind != MutliFactorAuthKind.None;
  }
}
