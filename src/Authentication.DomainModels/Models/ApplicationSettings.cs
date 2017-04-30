using Authentication.Domain.ModelContracts;

namespace Authentication.Domain.Models
{
  public class ApplicationSettings : IApplicationSettings
  {
    public string DbConnectionString { get; set; }
  }
}
