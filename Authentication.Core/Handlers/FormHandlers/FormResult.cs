namespace Authentication.Core.Handlers.FormHandlers
{
  public interface IFormResult
  {
    bool Success { get; }

    string ErrorMessage { get; }
  }


  public class FormResult : IFormResult
  {
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public static IFormResult Ok => new FormResult { Success = true };

    public static IFormResult Fail(string errorMessage) => new FormResult { Success = false, ErrorMessage = errorMessage };
  }
}
