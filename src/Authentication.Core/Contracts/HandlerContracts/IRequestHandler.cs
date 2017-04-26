using Authentication.Core.Handlers.RequestHandlers.FormResults;

namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface IRequestHandler<TRequest>
  {
    void Handle(TRequest request);
  }

  public interface IRequestHandler<TRequest, TReturn>
  {
    TReturn Handle(TRequest request);
  }

  public interface IRequest<TReturn, TRequest>
  {
    TReturn Handle(TRequest request);
  }

  public interface IFormResultRequestHandler<TRequest> : IRequestHandler<TRequest, IFormResult>
  {
    
  }
}