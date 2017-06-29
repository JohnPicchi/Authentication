using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.PresentationModels.EditModels
{
  public class VerifyLoginCodeEditModel : SendCodeEditModel
  {
    public string Code { get; set; }
  }
}
