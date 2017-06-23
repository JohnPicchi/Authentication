namespace Authentication.Domain.Models.Contracts
{
  public interface IApplicationSettings
  {
    string DbConnectionString { get; }

    int MaxFailedLoginAttempts { get; }
  }
}
