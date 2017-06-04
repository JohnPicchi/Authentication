namespace Authentication.Core.Requests.Contracts
{
  public interface IFormResultRequest<TRequest> : IRequest<(bool Success, string Message), TRequest>
  {
  }
}
