using System;
using Authentication.Domain;
using Autofac.Extras.DynamicProxy;

namespace Authentication.Account.Models
{
  public enum MutliFactorAuthKind
  {
    None = 0,
    Email = 1,
    Sms = 2
  }

  public class AccountProperties : DomainEntity<Guid>
  {
    public virtual int FailedLoginAttempts { get; private set; }

    public virtual void ResetFailedLoginAttempts()
    {
      FailedLoginAttempts = 0;
      LastFailedLoginAttemptDateTime = new DateTime();
    }

    public virtual DateTime? CurrentLoginDateTime { get; set; }

    public virtual DateTime? LastLoginDateTime { get; set; }

    public virtual DateTime? LastFailedLoginAttemptDateTime { get; set; }

    public virtual void UpdateLoginTimes()
    {
      LastLoginDateTime = CurrentLoginDateTime ?? DateTime.UtcNow;
      CurrentLoginDateTime = DateTime.UtcNow;
    }

    public virtual void UpdateFailedLoginAttempts()
    {
      if (LastLoginDateTime?.AddDays(1) > DateTime.UtcNow)
        ResetFailedLoginAttempts();

      FailedLoginAttempts += 1;
      LastFailedLoginAttemptDateTime = DateTime.UtcNow;
    }

    public virtual bool PasswordResetRequired { get; set; }

    public virtual Guid OpenConnectId { get; set; }

    public virtual MutliFactorAuthKind MultiFactorAuthKind { get; set; }

    public virtual bool HasMultiFactorAuth => MultiFactorAuthKind != MutliFactorAuthKind.None;
  }
}
