using Authentication.Core.Requests.Contracts;

namespace Authentication.Core
{
  public enum FormResultKind
  {
    Fail = 0,
    Success = 1,
  }

  public class FormResult : AbstractResult<FormResultKind>, IFormResult
  {
    public static FormResult Success 
      => new FormResult { Result = FormResultKind.Success };

    public static FormResult Fail(string errorMessage) 
      => new FormResult { Result = FormResultKind.Fail, ErrorMessage = errorMessage };
  }
}
