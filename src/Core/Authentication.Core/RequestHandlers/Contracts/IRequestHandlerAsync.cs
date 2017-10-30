using System.Threading.Tasks;

namespace Authentication.Core.RequestHandlers.Contracts
{
  public interface IRequestHandler<TReturn>
  {
    Task<TReturn> HandleAsync();
  }

  public interface IRequestHandler<TRequest, TReturn>
  {
    Task<TReturn> HandleAsync(TRequest request);
  }
}