using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class EditUserViewModel : EditUserEditModel
  {
    public bool VerifiedPhoneNumber { get; set; }

    public bool VerifiedEmail { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public int FailedAccessCount { get; set; }
  }
}
