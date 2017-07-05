using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers
{
  public class FormResult : IFormResult
  {
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public static FormResult Ok 
      => new FormResult { Success = true };

    public static FormResult Fail(string errorMessage) 
      => new FormResult { Success = false, ErrorMessage = errorMessage };
  }
}
