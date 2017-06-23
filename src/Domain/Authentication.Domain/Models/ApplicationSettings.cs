using Authentication.Domain.Models.Contracts;

namespace Authentication.Domain.Models
{
  public class ApplicationSettings : IApplicationSettings
  {
    public string DbConnectionString { get; set; }

    public int MaxFailedLoginAttempts { get; set; }
  }
}
