using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core
{
  public enum ResultKind
  {
    Other = -1,
    Fail = 0,
    Success = 1,
  }


  public abstract class AbstractResult<TResultKind>
    where TResultKind: struct
  {
    public TResultKind Result { get; set; }

    public string ErrorMessage { get; set; }
  }

  public class GenericResult : AbstractResult<ResultKind>
  {
    public static GenericResult Fail(string errorMessage)
      => new GenericResult {Result = ResultKind.Fail, ErrorMessage = errorMessage};

    public static GenericResult Success
      => new GenericResult {Result = ResultKind.Success};
  }
}
