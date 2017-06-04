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
    private readonly Models.Account.Factory accountFactory;

    public AccountFactory(Models.Account.Factory accountFactory)
    {
      this.accountFactory = accountFactory;
    }


    public IUserFactory UserFactory { get; set; }

    public IUserRepository UserRepository { get; set; }

    public IAccountRepository AccountRepository { get; set; }


    public Models.Account Create()
    {
      var account =  accountFactory.Invoke(
        AccountRepository, 
        UserRepository, 
        UserFactory);

      account.User = UserFactory.Create();

      return account;
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