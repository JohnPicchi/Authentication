using Authentication.Application.DomainModels.Contracts;

namespace Authentication.Application.DomainModels
{
  public class ApplicationSettings : IApplicationSettings
  {
    public string DbConnectionString { get; set; }

    public int MaxFailedLoginAttempts { get; set; }
  }
}
