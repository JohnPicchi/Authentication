using System.Threading.Tasks;

namespace Authentication.Core.Requests.Contracts
{
  public interface IRequestAsync<TReturn>
  {
    Task<TReturn> HandleAsync();
  }

  public interface IRequestAsync<TReturn, TRequest>
  {
    Task<TReturn> HandleAsync(TRequest request);
  }
}
