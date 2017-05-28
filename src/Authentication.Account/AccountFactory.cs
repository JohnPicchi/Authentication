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

    public IAccountRepository AccountRepository { get; set; }

    public AccountFactory(IUserFactory userFactory, IUserRepository userRepository)
    {
      this.userFactory = userFactory;
      this.userRepository = userRepository;
    }

    public Models.Account Create()
    {
      return new Models.Account(AccountRepository, userFactory, userRepository);
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