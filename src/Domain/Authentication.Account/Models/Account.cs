using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Authentication.Core.Models.Contracts;
using Authentication.Domain;
using Authentication.User;

namespace Authentication.Account.Models
{
  public class Account : DomainEntity<Guid>
  {
    public const string INCORRECT_LOGIN = "Incorrect username and/or password";
    public const string INCORRECT_TOKEN = "Incorrect token";

    private readonly IAccountRepository accountRepository;
    private readonly IUserFactory userFactory;
    private readonly IUserRepository userRepository;
    private readonly IApplicationSettings applicationSettings;

    private AccountProperties accountProperties;
    private User.Models.User user;

    private IList<Claim> claims;
    private IList<Token> accountTokens;
    private IList<AccountLock> accountLocks;

    public Account(
      IAccountRepository accountRepository, 
      IUserRepository userRepository,
      IUserFactory userFactory,
      IApplicationSettings applicationSettings)
    {
      this.accountRepository = accountRepository;
      this.userRepository = userRepository;
      this.userFactory = userFactory;
      this.applicationSettings = applicationSettings;
    }

    public delegate Account Factory(
      IAccountRepository accountRepository,
      IUserRepository userRepository,
      IUserFactory userFactory);

    public virtual string Username { get; private set; }

    public virtual string Password { get; private set; }

    public virtual bool IsAuthenticated { get; private set; }

    public virtual bool IsVerified { get; set; } = false;

    public virtual bool IsLocked => Locks.Any(l => l.IsValid);

    public virtual AccountProperties Properties
    {
      get => accountProperties ?? (accountProperties = this.IsNew
               ? new AccountProperties()
               : accountRepository.AccountProperties(this.Id) ?? new AccountProperties());

      set => accountProperties = value;
    }

    public virtual User.Models.User User
    {
      get => user ?? (user = this.IsNew
               ? userFactory.Create()
               : userRepository.FindByAccountId(this.Id) ?? userFactory.Create());

      set => user = value;
    }

    public virtual IList<Claim> Claims
    {
      get => claims ?? (claims = this.IsNew
               ? new List<Claim>()
               : accountRepository.AccountClaims(this.Id) ?? new List<Claim>());

      set => claims = value;
    }

    public virtual IList<Token> Tokens
    {
      get => accountTokens ?? (accountTokens = this.IsNew
              ? new List<Token>() 
              : accountRepository.AccountTokens(this.Id) ?? new List<Token>());

      set => accountTokens = value;
    }

    public virtual IList<AccountLock> Locks
    {
      get => accountLocks ?? (accountLocks = this.IsNew
               ? new List<AccountLock>()
               : accountRepository.AccountLocks(this.Id) ?? new List<AccountLock>());

      set => accountLocks = value;
    }

    public virtual IAuthenticationResult MutliFactorAuthenticate(string tokenValue)
    {
      if (VerifyToken(tokenValue, TokenKind.MultiFactorAuth))
      {
        Properties.ResetFailedLoginAttempts();
        Properties.UpdateLoginTimes();
        IsAuthenticated = true;
        return AuthenticationResult.Success;
      }

      Properties.UpdateFailedLoginAttempts();
      FailedLoginAccountLockCheck();

      return IsLocked 
        ? AuthenticationResult.Fail(Locks.First(l => l.IsValid).Message)
        : AuthenticationResult.Fail(INCORRECT_TOKEN);
    }

    public virtual IAuthenticationResult Authenticate(string password)
    {
      if (!IsLocked)
      {
        var correctPassword = VerifyPassword(password);
        if (correctPassword)
        {
          Properties.ResetFailedLoginAttempts();
          if (Properties.HasMultiFactorAuth)
          {
            //TODO: Generate token
            return AuthenticationResult.MultiFactor;
          }

          Properties.UpdateLoginTimes();
          IsAuthenticated = true;
          return AuthenticationResult.Success;
        }

        Properties.UpdateFailedLoginAttempts();
        FailedLoginAccountLockCheck();
      }

      return IsLocked 
        ? AuthenticationResult.Fail(Locks.First(l => l.IsValid).Message)
        : AuthenticationResult.Fail(INCORRECT_LOGIN);
    }

    private void FailedLoginAccountLockCheck()
    {
      if (Properties.FailedLoginAttempts >= applicationSettings.MaxFailedLoginAttempts)
      {
        Locks.Add(AccountLock.MaxLoginAttempts);
        Properties.ResetFailedLoginAttempts();
      }
    }

    public virtual void SetUsername(string username) => Username = username;

    public virtual void SetPassword(string password) => Password = BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, Password);

    public virtual bool VerifyToken(string tokenValue, TokenKind tokenKind)
    {
      return Tokens.Any(t => t.IsValid && t.Value == tokenValue && t.Kind == tokenKind);
    }
  }
}
