using System;
using Authentication.Domain;
using Authentication.User;

namespace Authentication.Account
{
  public interface IAccountFactory : IFactory<Models.Account>
  {
    Models.Account Create(string username, string password);
  }

  public class AccountFactory : IAccountFactory
  {
    private readonly IUserFactory userFactory;
    private IUserRepository userRepository;

    public AccountFactory(IUserFactory userFactory, IUserRepository userRepository)
    {
      this.userFactory = userFactory;
      this.userRepository = userRepository;
    }

    public Models.Account Create()
    {
      return new Models.Account(userFactory, userRepository);
    }

    public Models.Account Create(string username, string password)
    {
      var account = Create();

      account.Username = username;
      account.Password = BCrypt.Net.BCrypt.HashPassword(password);

      return account;
    }
  }
}