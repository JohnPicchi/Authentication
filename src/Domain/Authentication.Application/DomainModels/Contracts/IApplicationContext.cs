
using System.Threading.Tasks;

namespace Authentication.Application.DomainModels.Contracts
{
  public interface IApplicationContext
  {
    IApplicationSettings ApplicationSettings { get; }

    User.Models.User User { get; }
  }
}
