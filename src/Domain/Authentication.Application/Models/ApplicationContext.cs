using IApplicationContext = Authentication.Core.Models.Contracts.IApplicationContext;
using IApplicationSettings = Authentication.Core.Models.Contracts.IApplicationSettings;

namespace Authentication.Application.Models
{
  public class ApplicationContext : IApplicationContext
  {
    public IApplicationSettings ApplicationSettings { get; set; }
  }
}