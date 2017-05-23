using System;
using Authentication.Domain;
using Authentication.User;

namespace Authentication.Account
{
  public interface IAccountFactory : IFactory<Models.Account>
  {
    Models.Account Create(string username, string passwaord);
  }

  public class AccountFactory : IAccountFactory
  {
    private readonly IUserFactory userFactory;

    public AccountFactory(IUserFactory userFactory)
    {
      this.userFactory = userFactory;
    }

    public Models.Account Create()
    {
      return new Models.Account(userFactory);
    }

    public Models.Account Create(string username, string passwaord)
    {
      var account = Create();

      account.Username = username;
      account.Password = passwaord;

      return account;
    }
  }
}
