using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Account.EditModels
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
