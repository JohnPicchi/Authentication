namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface IRequestHandler<TRequest, TReturn> : IHandler<TRequest, TReturn>
    where TRequest : IRequest
  {

  }

  public interface IRequest
  {

  }
}
