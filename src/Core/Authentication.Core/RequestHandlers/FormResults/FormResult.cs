using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers.FormResults
{
  public class FormResult : IFormResult
  {
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public static IFormResult Ok => new FormResult { Success = true };

    public static IFormResult Fail(string errorMessage) => new FormResult { Success = false, ErrorMessage = errorMessage };
  }
}
