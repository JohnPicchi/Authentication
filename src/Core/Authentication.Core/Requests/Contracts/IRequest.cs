using System.Threading.Tasks;

namespace Authentication.Core.Requests.Contracts
{
  public interface IRequest<TReturn>
  {
    Task<TReturn> HandleAsync();
  }

  public interface IRequest<TReturn, TRequest>
  {
    Task<TReturn> HandleAsync(TRequest request);
  }
}
