namespace Authentication.Core.Requests.Contracts
{
  public interface IFormResult
  {
    bool Success { get; }

    string ErrorMessage { get; }
  }
}
