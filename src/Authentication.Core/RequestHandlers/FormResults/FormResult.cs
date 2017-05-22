using System.Collections.Generic;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class FormResult : IFormResult
  {
    public bool Success { get; set; }

    public IList<string> ErrorMessages { get; set; } = new List<string>();

    public static FormResult Ok => new FormResult {Success = true};

    public static FormResult Fail(string errorMessage)
    {
      var formResult = new FormResult();
      formResult.ErrorMessages.Add(errorMessage);
      formResult.Success = false;
      return formResult;
    }
  }
}
