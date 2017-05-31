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
    public AccountProperties()
    {

    }

    public delegate AccountProperties Factory();

    public virtual int FailedLoginAttempts { get; set; }

    public virtual void ResetFailedLoginAttempts() => FailedLoginAttempts = 0;

    public virtual DateTime? CurrentLoginDateTime { get; set; }

    public virtual DateTime? LastLoginDateTime { get; set; }

    public virtual bool UpdatedLoginTimes { get; private set;}

    public virtual void UpdateLoginTimes()
    {
      if (!UpdatedLoginTimes)
      {
        LastLoginDateTime = CurrentLoginDateTime ?? DateTime.UtcNow;
        CurrentLoginDateTime = DateTime.UtcNow;
      }
      UpdatedLoginTimes = true;
    }

    public virtual bool PasswordResetRequired { get; set; }

    public virtual Guid OpenConnectId { get; set; }

    public virtual MutliFactorAuthKind MultiFactorAuthKind { get; set; }

    public virtual bool HasMultiFactorAuth => MultiFactorAuthKind != MutliFactorAuthKind.None;
  }
}
