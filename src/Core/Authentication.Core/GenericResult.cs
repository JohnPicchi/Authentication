using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core
{
  public enum ResultKind
  {
    Other = -1,
    Failure = 0,
    Success = 1,
  }


  public abstract class AbstractResult
  {
    public ResultKind Result { get; set; }

    public bool Success => Result == ResultKind.Success;

    public string ErrorMessage { get; set; } = String.Empty;
  }

  public class GenericResult : AbstractResult
  {
    public static GenericResult Fail(string errorMessage)
      => new GenericResult {Result = ResultKind.Failure, ErrorMessage = errorMessage};

    public static GenericResult Ok
      => new GenericResult {Result = ResultKind.Success};
  }
}
