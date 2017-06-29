using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.EditModels
{
  public class SendCodeEditModel
  {
    [HiddenInput]
    public string ReturnUrl { get; set; }

    [HiddenInput]
    public bool RememberMe { get; set; }

    [HiddenInput]
    public string CodeProvider { get; set; }
  }
}
