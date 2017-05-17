namespace Authentication.Domain.Account
{
  public interface IAccountRepository
  {
    bool AccountExists(string accountId);

    void Add(Models.Account account);

    Models.Account Find(string accountId);

    void Remove(Models.Account account);

    void Remove(string username);
  }
}
