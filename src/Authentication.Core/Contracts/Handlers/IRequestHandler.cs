namespace Authentication.Core.Contracts.Handlers
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