using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers.Contracts
{
  public interface IFormResultRequestHandler<TRequest> : IRequestHandler<TRequest, (bool Success, string Message)>
  {

  }
}
