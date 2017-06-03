using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Domain;
using Authentication.User;
using Autofac.Extras.DynamicProxy;


namespace Authentication.Account.Models
{
  public class Account : DomainEntity<Guid>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IUserFactory userFactory;
    private readonly IUserRepository userRepository;

    private User.Models.User user;
    private AccountProperties properties;

    private IList<AccountToken> accountTokens = new List<AccountToken>();
    private IList<AccountClaim> accountClaims = new List<AccountClaim>();
    private IList<AccountLock> accountLocks = new List<AccountLock>();

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

    public virtual bool IsVerified { get; set; }

    public virtual bool IsAuthenticated { get; private set; }

    public virtual bool IsLocked => accountLocks.Any(l => l.IsValid);

    public virtual AccountProperties Properties
    {
      get { return properties; }

      set => properties = value;
    }

    public virtual User.Models.User User
    {
      get { return user; }

      set => user = value;
    }

    public virtual void AddClaim(AccountClaim accountClaim)
    {
      //TODO
    }

    public virtual void RemoveClaim(AccountClaim accountClaim)
    {
      //TODO
    }

    public virtual void AddLock(AccountLock accountLock)
    {
      if(accountLock != null)
        accountLocks?.Add(accountLock);
    }

    public virtual void RemoveLock(AccountLock accountLock)
    {
      var index = accountLocks?.IndexOf(accountLock);
      if (index >= 0)
        accountLocks.RemoveAt(index.Value);
    }

    public virtual void AddToken(AccountToken token)
    {
      if(token != null)
        accountTokens?.Add(token);
    }

    public virtual void RemoveToken(AccountToken token)
    {
      var index = accountTokens?.IndexOf(token);
      if(index >= 0)
        accountTokens.RemoveAt(index.Value);
    }

    public virtual IAuthenticationResult MutliFactorAuthenticate(string tokenValue)
    {
      //return AuthenticationResult.Success;

      return AuthenticationResult.Fail("Incorrect token value");
    }

    public virtual IAuthenticationResult Authenticate(string password)
    {
      if (!IsLocked && VerifyPassword(password))
      {
        Properties.ResetFailedLoginAttempts();
        if (Properties.HasMultiFactorAuth)
        {
          //TODO
          return AuthenticationResult.Success;
        }
        else
        {
          Properties.UpdateLoginTimes();
          IsAuthenticated = true;
          return AuthenticationResult.Success;
        }
      }
      return AuthenticationResult.Fail("Incorrect username and/or password");
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
