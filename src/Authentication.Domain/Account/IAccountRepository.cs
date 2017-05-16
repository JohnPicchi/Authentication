namespace Authentication.Domain.Account
{
  public interface IAccountRepository
  {
    bool UsernameExists(string username);

    Models.Account Add(Models.Account account);

    Models.Account Find(string username);

    void Remove(Models.Account account);

    void Remove(string username);
  }
}
