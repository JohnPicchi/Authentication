using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Domain;
using Authentication.User;


namespace Authentication.Account.Models
{
  public class Account : Entity<Guid>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IUserFactory userFactory;
    private readonly IUserRepository userRepository;

    private User.Models.User user;
    private AccountProperties properties;

    private IList<AccountToken> tokens;
    private IList<AccountLock> locks;

    public Account(
      IAccountRepository accountRepository, 
      IUserFactory userFactory, 
      IUserRepository userRepository)
    {
      this.accountRepository = accountRepository;
      this.userFactory = userFactory;
      this.userRepository = userRepository;
    }

    public string Username { get; private set; }
    
    public string Password { get; private set; }

    public bool IsAuthenticated { get; private set; }

    public bool IsLocked => locks.Any(l => l.IsValid);

    public bool IsVerified { get; set; }

    public AccountProperties Properties
    {
      get => properties ?? (properties = this.IsNew
               ? new AccountProperties()
               : accountRepository.AccountProperties(this.Id));

      set => properties = value;
    } 

    public User.Models.User User
    {
      get => user ?? (user = this.IsNew
               ? userFactory.Create()
               : null);   //TODO

      set => user = value;
    }

    public IEnumerable<AccountToken> Tokens
    {
      get => tokens ?? (tokens = this.IsNew
               ? new List<AccountToken>()
               : accountRepository.AccountTokens(this.Id));

      private set => tokens = value.ToList();
    }

    public IEnumerable<AccountLock> Locks
    {
      get => locks ?? (locks = this.IsNew
               ? new List<AccountLock>()
               : accountRepository.AccountLocks(this.Id));

      private set => locks = value.ToList();
    }

    public void AddLock(AccountLock accountLock)
    {
      locks.Add(accountLock);
    }

    public void RemoveLock(AccountLock accountLock)
    {
      var index = locks.IndexOf(accountLock);
      if (index >= 0)
        locks.RemoveAt(index);
    }

    public void AddToken(AccountToken token)
    {
      tokens.Add(token);
    }

    public void RemoveToken(AccountToken token)
    {
      var index = tokens.IndexOf(token);
      if(index >= 0)
        tokens.RemoveAt(index);
    }

    public AuthenticationResult MutliFactorAuthenticate(string tokenValue)
    {
      return AuthenticationResult.Fail;
    }

    public AuthenticationResult Authenticate(string password)
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

    public void SetUsername(string username) => Username = username;

    public void SetPassword(string password) => Password = BCrypt.Net.BCrypt.HashPassword(password);

    private bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, Password);

    public bool VerifyToken(string tokenValue, TokenKind tokenKind)
    {
      return false;
    }
  }
}