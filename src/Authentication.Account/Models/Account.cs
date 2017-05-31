﻿using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Account.Factories;
using Authentication.Account.Repositories;
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
    private readonly IAccountPropertiesFactory accountPropertiesFactory;

    private User.Models.User user;
    private AccountProperties properties;

    private IList<AccountToken> accountTokens = new List<AccountToken>();
    private IList<AccountClaim> accountClaims = new List<AccountClaim>();
    private IList<AccountLock> accountLocks = new List<AccountLock>();

    public Account(
      IAccountRepository accountRepository, 
      IUserRepository userRepository,
      IAccountPropertiesFactory accountPropertiesFactory)
    {
      this.accountRepository = accountRepository;
      this.userRepository = userRepository;
      this.accountPropertiesFactory = accountPropertiesFactory;
    }

    public delegate Account Factory(
      IAccountRepository accountRepository,
      IUserRepository userRepository,
      IAccountPropertiesFactory accountPropertiesFactory);

    public virtual string Username { get; private set; }

    public virtual string Password { get; private set; }

    public virtual bool IsVerified { get; set; }

    public virtual bool IsAuthenticated { get; private set; }

    public virtual bool IsLocked => accountLocks.Any(l => l.IsValid);

    public virtual AccountProperties Properties
    {
      get => properties ?? (properties = this.IsNew
               ? accountPropertiesFactory.Create()
               : accountRepository.AccountProperties(this.Id) 
               ?? accountPropertiesFactory.Create());
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

    public virtual (bool Success, AuthStatus Status, string Message) MutliFactorAuthenticate(string tokenValue)
    {
      //return (Success: true, Status: AuthStatus.Sucess, Message: null);
      return (Success: false, Status: AuthStatus.Fail, Message: "Incorrect token");
    }

    public virtual (bool Success, AuthStatus Status, string Message) Authenticate(string password)
    {
      if (!IsLocked && VerifyPassword(password))
      {
        Properties.ResetFailedLoginAttempts();
        if (Properties.HasMultiFactorAuth)
        {
          //TODO
          return (Success: true, Status: AuthStatus.Sucess, Message: null);
        }
        else
        {
          Properties.UpdateLoginTimes();
          IsAuthenticated = true;
          return (Success: true, AuthStatus.Sucess, Message: null);
        }
      }
      return (Success: false, Status: AuthStatus.Fail, Message: "Incorrect username and/or password");
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
