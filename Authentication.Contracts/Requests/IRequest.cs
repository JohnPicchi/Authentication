namespace Authentication.Contracts.Requests
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
