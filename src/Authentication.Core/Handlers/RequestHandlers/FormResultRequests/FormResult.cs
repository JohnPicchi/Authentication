using Authentication.Core.Contracts;

namespace Authentication.Core.Handlers.RequestHandlers.FormResultRequests
{
  public class FormResult : IFormResult
  {
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public static IFormResult Ok => new FormResult { Success = true };

    public static IFormResult Fail(string errorMessage) => new FormResult { Success = false, ErrorMessage = errorMessage };
  }
}
