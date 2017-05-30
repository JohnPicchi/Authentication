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

  public class AccountProperties : Entity<Guid>
  {

    private int failedLoginAttempts;
    private DateTime? currentLoginDateTime;
    private DateTime? lastLoginDateTime;
    private bool passwordResetRequired;
    private Guid openConnectId;
    private MutliFactorAuthKind multiFactorAuthKind;

    public AccountProperties()
    {

    }

    public delegate AccountProperties Factory();

    public virtual int FailedLoginAttempts
    {
      get => failedLoginAttempts;
      set => (failedLoginAttempts, IsDirty) = (value, true);
    }

    public virtual void ResetFailedLoginAttempts() => FailedLoginAttempts = 0;

    public virtual DateTime? CurrentLoginDateTime
    {
      get => currentLoginDateTime;
      private set => (currentLoginDateTime, IsDirty) = (value, true);
    }

    public virtual DateTime? LastLoginDateTime
    {
      get => lastLoginDateTime;
      private set => (lastLoginDateTime, IsDirty) = (value, true);
    }

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

    public virtual bool PasswordResetRequired
    {
      get => passwordResetRequired;
      set => (passwordResetRequired, IsDirty) = (value, true);
    }

    public virtual Guid OpenConnectId
    {
      get => openConnectId;
      private set => (openConnectId, IsDirty) = (value, true);
    }

    public virtual MutliFactorAuthKind MultiFactorAuthKind
    {
      get => multiFactorAuthKind;
      set => (multiFactorAuthKind, IsDirty) = (value, true);
    }

    public virtual bool HasMultiFactorAuth => MultiFactorAuthKind != MutliFactorAuthKind.None;
  }
}
