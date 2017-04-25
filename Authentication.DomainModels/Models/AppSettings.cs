using Authentication.DomainModels.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Authentication.DomainModels.Models
{
  public class AppSettings : IAppSettings
  {
    public string DbConnectionString { get; set; }
  }
}
