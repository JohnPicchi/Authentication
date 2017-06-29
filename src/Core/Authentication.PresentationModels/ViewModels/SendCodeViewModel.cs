using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.EditModels;

namespace Authentication.PresentationModels.ViewModels
{
  public class SendCodeViewModel : SendCodeEditModel
  {
    public IEnumerable<string> CodeProviders { get; set; }
  }
}
