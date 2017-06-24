namespace Authentication.Application.DomainModels.Contracts
{
  public interface IApplicationSettings
  {
    string DbConnectionString { get; }

    int MaxFailedLoginAttempts { get; }
  }
}
