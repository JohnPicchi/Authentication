using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.EditModels;

namespace Authentication.PresentationModels.ViewModels
{
  public class SendLoginCodeViewModel : SendLoginCodeEditModel
  {
    public IEnumerable<string> CodeProviders { get; set; }
  }
}
