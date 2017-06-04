namespace Authentication.Core.Requests.Contracts
{
  public interface IRequest<TReturn>
  {
    TReturn Handle();
  }

  public interface IRequest<TReturn, TRequest>
  {
    TReturn Handle(TRequest request);
  }
}
