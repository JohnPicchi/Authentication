using Authentication.Domain.ModelContracts;

namespace Authentication.Domain.Models
{
  public class ApplicationContext : IApplicationContext
  {
    public IApplicationSettings ApplicationSettings { get; set; }

    public IUser User { get; set; }
  }
}