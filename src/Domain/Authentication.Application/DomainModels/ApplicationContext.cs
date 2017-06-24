using IApplicationSettings = Authentication.Application.DomainModels.Contracts.IApplicationSettings;

namespace Authentication.Application.DomainModels
{
  public class ApplicationContext : Contracts.IApplicationContext
  {
    public IApplicationSettings ApplicationSettings { get; set; }
  }
}