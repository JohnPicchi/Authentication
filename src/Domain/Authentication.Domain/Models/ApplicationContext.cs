using IApplicationSettings = Authentication.Domain.Models.Contracts.IApplicationSettings;

namespace Authentication.Domain.Models
{
  public class ApplicationContext : Contracts.IApplicationContext
  {
    public IApplicationSettings ApplicationSettings { get; set; }
  }
}