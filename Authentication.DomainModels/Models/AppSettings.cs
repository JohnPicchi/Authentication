using Authentication.DomainModels.Contracts;
using Microsoft.Extensions.Configuration;

namespace Authentication.DomainModels.Models
{
  public class AppSettings : IAppSettings
  {
    public string DbConnectionString { get; set; }
  }
}
