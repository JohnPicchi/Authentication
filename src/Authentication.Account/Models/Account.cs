using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Account.Repositories;
using Authentication.Domain;
using Authentication.User;


namespace Authentication.Account.Models
{
  public class Account : DomainEntity<Guid>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IUserFactory userFactory;
    private readonly IUserRepository userRepository;

    private User.Models.User user;
    private AccountProperties properties;
    private IList<AccountToken> tokens = new List<AccountToken>();
    private IList<AccountLock> locks = new List<AccountLock>();

    public Account(
      IAccountRepository accountRepository, 
      IUserFactory userFactory, 
      IUserRepository userRepository)
    {
      this.accountRepository = accountRepository;
      this.userFactory = userFactory;
      this.userRepository = userRepository;
    }

    public delegate Account Factory(
      IAccountRepository accountRepository,
      IUserFactory userFactory,
      IUserRepository userRepository);

    public virtual string Username { get; private set; }

    public virtual string Password { get; private set; }

    public virtual bool IsVerified { get; set; }

    public virtual bool IsAuthenticated { get; private set; }

    public virtual bool IsLocked => locks.Any(l => l.IsValid);

    public virtual AccountProperties Properties
    {
      get => properties ?? (properties = this.IsNew
               ? new AccountProperties()
               : accountRepository.AccountProperties(this.Id)) ?? new AccountProperties();

      set => properties = value;
    } 

    public virtual User.Models.User User
    {
      get => user ?? (user = this.IsNew
               ? userFactory.Create()
               : userRepository.FindByAccountId(this.Id)) ?? userFactory.Create();

      set => user = value;
    }

    public virtual void AddLock(AccountLock accountLock)
    {
      if (accountLock != null)
        locks?.Add(accountLock);
    }

    public virtual void RemoveLock(AccountLock accountLock)
    {
      var index = locks?.IndexOf(accountLock);
      if (index >= 0)
        locks.RemoveAt(index.Value);
    }

    public virtual void AddToken(AccountToken token)
    {
      if(token != null)
        tokens?.Add(token);
    }

    public virtual void RemoveToken(AccountToken token)
    {
      var index = tokens?.IndexOf(token);
      if(index >= 0)
        tokens.RemoveAt(index.Value);
    }

    public virtual AuthenticationResult MutliFactorAuthenticate(string tokenValue)
    {
      return AuthenticationResult.Fail;
    }

    public virtual AuthenticationResult Authenticate(string password)
    {
      if (!IsLocked && VerifyPassword(password))
      {
        Properties.ResetFailedLoginAttempts();
        if (Properties.HasMultiFactorAuth)
        {
          //TODO
        }
        else
        {
          Properties.UpdateLoginTimes();
          IsAuthenticated = true;
          return AuthenticationResult.Success;
        }
      }
      return AuthenticationResult.Fail;
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