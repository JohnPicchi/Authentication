using System.Threading.Tasks;

namespace Authentication.Core.RequestHandlers.Contracts
{
  public interface IRequestHandlerAsync<TReturn>
  {
    Task<TReturn> HandleAsync();
  }

  public interface IRequestHandlerAsync<TRequest, TReturn>
  {
    Task<TReturn> HandleAsync(TRequest request);
  }
}