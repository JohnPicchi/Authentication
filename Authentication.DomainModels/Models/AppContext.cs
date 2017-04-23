using Authentication.DomainModels.Contracts;

namespace Authentication.DomainModels.Models
{
  public class AppContext : IAppContext
  {
    public IAppSettings AppSettings { get; set; }

    public IAppUser AppUser { get; set; }
  }
}