using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class RoleClaimViewModel : RoleClaimEditModel
  {
    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }
  }
}
