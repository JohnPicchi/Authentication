using System.Threading.Tasks;

namespace Authentication.Core.Requests.Contracts
{
  public interface IFormResultRequestAsync<TRequest> : IRequestAsync<IFormResult, TRequest>
  {
  }
}
