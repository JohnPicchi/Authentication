using System.Collections.Generic;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class FormResult : IFormResult
  {

    public bool Success { get; set; }

    public string ErrorMessage { get; private set; }

    public static FormResult Ok => new FormResult {Success = true};

    public static FormResult Fail(string errorMessage) => new FormResult {Success = false, ErrorMessage = errorMessage};
  }
}
