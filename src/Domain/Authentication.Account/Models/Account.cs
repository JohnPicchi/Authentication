using System;
using System.Collections.Generic;
using System.Linq;
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

    private AccountProperties accountProperties;
    private User.Models.User user;

    private IList<AccountClaim> accountClaims;
    private IList<AccountToken> accountTokens;
    private IList<AccountLock> accountLocks;

    public Account(
      IAccountRepository accountRepository, 
      IUserRepository userRepository)
    {
      this.accountRepository = accountRepository;
      this.userRepository = userRepository;
    }

    public delegate Account Factory(
      IAccountRepository accountRepository,
      IUserRepository userRepository,
      IUserFactory userFactory);

    public virtual string Username { get; private set; }

    public virtual string Password { get; private set; }

    public virtual bool IsAuthenticated { get; private set; }

    public virtual bool IsVerified { get; set; }

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

    public virtual IList<AccountClaim> Claims
    {
      get => accountClaims ?? (accountClaims = this.IsNew
               ? new List<AccountClaim>()
               : accountRepository.AccountClaims(this.Id) ?? new List<AccountClaim>());

      set => accountClaims = value;
    }

    public virtual IList<AccountToken> Tokens
    {
      get => accountTokens ?? (accountTokens = this.IsNew
              ? new List<AccountToken>() 
              : accountRepository.AccountTokens(this.Id) ?? new List<AccountToken>());

      set => accountTokens = value;
    }

    public virtual IList<AccountLock> Locks
    {
      get => accountLocks ?? (accountLocks = this.IsNew
               ? new List<AccountLock>()
               : accountRepository.AccountLocks(this.Id) ?? new List<AccountLock>());

      set => accountLocks = value;
    }

    public virtual void AddClaim(AccountClaim accountClaim) => Claims.Add(accountClaim);

    public virtual void AddToken(AccountToken token) => Tokens.Add(token);

    public virtual void AddLock(AccountLock accountLock) => Locks.Add(accountLock);

    public virtual void RemoveClaim(AccountClaim accountClaim) => Claims.RemoveAt(Claims.IndexOf(accountClaim));

    public virtual void RemoveToken(AccountToken token) => Tokens.RemoveAt(Tokens.IndexOf(token));

    public virtual void RemoveLock(AccountLock accountLock) => Locks.RemoveAt(Locks.IndexOf(accountLock));

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
      //TODO: Max login attempts reached then lock account;

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
            //TODO
            return AuthenticationResult.MultiFactor;
          }

          Properties.UpdateLoginTimes();
          IsAuthenticated = true;
          return AuthenticationResult.Success;
        }

        Properties.UpdateFailedLoginAttempts();
        //TODO: Max login attempts reached then lock account
        
      }

      return IsLocked 
        ? AuthenticationResult.Fail(Locks.First(l => l.IsValid).Message)
        : AuthenticationResult.Fail(INCORRECT_LOGIN);
    }

    public virtual void SetUsername(string username) => Username = username;

    public virtual void SetPassword(string password) => Password = BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, Password);

    public virtual bool VerifyToken(string tokenValue, TokenKind tokenKind)
    {
      return false;
    }
  }
}
