using IApplicationContext = Authentication.Core.Models.Contracts.IApplicationContext;
using IApplicationSettings = Authentication.Core.Models.Contracts.IApplicationSettings;

namespace Authentication.Core.Models
{
  public class ApplicationContext : IApplicationContext
  {
    public IApplicationSettings ApplicationSettings { get; set; }

  }
}