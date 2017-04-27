namespace Authentication.Core.Contracts
{
  public interface IFormResult
  {
    bool Success { get; }

    string ErrorMessage { get; }
  }
}
