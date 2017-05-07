using Authentication.Core.Models.Contracts;

namespace Authentication.Core.Models
{
  public class ApplicationSettings : IApplicationSettings
  {
    public string DbConnectionString { get; set; }
  }
}
