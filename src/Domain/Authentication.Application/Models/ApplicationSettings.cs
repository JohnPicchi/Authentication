using Authentication.Core.Models.Contracts;

namespace Authentication.Application.Models
{
  public class ApplicationSettings : IApplicationSettings
  {
    public string DbConnectionString { get; set; }

    public int MaxFailedLoginAttempts { get; set; }
  }
}
