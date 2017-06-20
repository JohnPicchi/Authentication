namespace Authentication.Core.Models.Contracts
{
  public interface IApplicationSettings
  {
    string DbConnectionString { get; }

    int MaxFailedLoginAttempts { get; }
  }
}
