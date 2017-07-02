namespace Authentication.Application.DomainModels.Contracts
{
  public interface IApplicationSettings
  {
    string DbConnectionString { get; }

    ApplicationEmailSettings Email { get; }

    int MaxFailedLoginAttempts { get; }
  }
}
