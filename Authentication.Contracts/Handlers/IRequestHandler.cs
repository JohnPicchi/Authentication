using Authentication.Contracts.Requests;

namespace Authentication.Contracts.Handlers
{
  public interface IRequestHandler<TReturn>
  {
    TReturn Handle();
  }

  public interface IRequestHandler<TRequest, TReturn>
  {
    TReturn Handle(TRequest request);
  }
}