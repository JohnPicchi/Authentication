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
      LastLoginAttempt = new DateTime();
    }

    public virtual DateTime? CurrentLogin { get; set; }

    public virtual DateTime? LastLogin { get; set; }

    public virtual DateTime? LastLoginAttempt { get; set; }

    public virtual void UpdateLoginTimes()
    {
      LastLogin = CurrentLogin ?? DateTime.UtcNow;
      CurrentLogin = DateTime.UtcNow;
    }

    public virtual void UpdateFailedLoginAttempts()
    {
      if (LastLogin?.AddDays(1) > DateTime.UtcNow)
        ResetFailedLoginAttempts();

      FailedLoginAttempts += 1;
      LastLoginAttempt = DateTime.UtcNow;
    }

    public virtual bool PasswordResetRequired { get; set; }

    public virtual Guid OpenIdConnectId { get; set; }

    public virtual MutliFactorAuthKind MultiFactorAuthKind { get; set; }

    public virtual bool HasMultiFactorAuth => MultiFactorAuthKind != MutliFactorAuthKind.None;
  }
}
