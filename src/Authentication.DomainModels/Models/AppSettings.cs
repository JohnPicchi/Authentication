using Authentication.DomainModels.Contracts;

namespace Authentication.DomainModels.Models
{
  public class AppSettings : IAppSettings
  {
    public string DbConnectionString { get; set; }
  }
}
