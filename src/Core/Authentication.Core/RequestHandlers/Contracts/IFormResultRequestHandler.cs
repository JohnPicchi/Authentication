using System.Threading.Tasks;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers.Contracts
{
  public interface IFormResultRequestHandler<TRequest> : IRequestHandler<TRequest, IFormResult>
  {

  }

  public interface IFormResultRequestHandlerAsync<TRequest> : IRequestHandlerAsync<TRequest, IFormResult>
  {

  }
}
