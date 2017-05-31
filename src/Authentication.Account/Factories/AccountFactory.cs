﻿using Authentication.Account.Repositories;
using Authentication.Domain;
using Authentication.User;

namespace Authentication.Account.Factories
{
  public interface IAccountFactory : IFactory<Models.Account>
  {
    Models.Account Create(string username, string password);
  }

  public class AccountFactory : IAccountFactory
  {
    private readonly Models.Account.Factory accountFactory;

    public AccountFactory(Models.Account.Factory accountFactory)
    {
      this.accountFactory = accountFactory;
    }



    public IUserRepository UserRepository { get; set; }

    public IAccountRepository AccountRepository { get; set; }

    public IAccountPropertiesFactory AccountPropertiesFactory { get; set; }



    public Models.Account Create()
    {
      return accountFactory.Invoke(AccountRepository, UserRepository, AccountPropertiesFactory);
    }

    public Models.Account Create(string username, string password)
    {
      var account = Create();

      account.SetUsername(username);
      account.SetPassword(password);

      return account;
    }
  }
}