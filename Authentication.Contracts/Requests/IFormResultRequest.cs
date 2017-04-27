namespace Authentication.Contracts.Requests
{
  public interface IFormResultRequest : IRequest { } 

  public interface IFormResultRequest<TRequest> : IRequest<IFormResult, TRequest>
    where TRequest: IFormResultRequest
  {
  }
}
