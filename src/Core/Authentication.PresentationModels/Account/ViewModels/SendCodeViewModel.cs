using System.Collections.Generic;
using Authentication.PresentationModels.Account.EditModels;

namespace Authentication.PresentationModels.Account.ViewModels
{
  public class SendCodeViewModel : SendCodeEditModel
  {
    public IEnumerable<string> CodeProviders { get; set; }
  }
}
