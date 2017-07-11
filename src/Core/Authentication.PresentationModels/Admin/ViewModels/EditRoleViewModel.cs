using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class EditRoleViewModel : EditRoleEditModel
  {
    public IEnumerable<RoleClaimEditModel> RoleClaims { get; set; }
  }
}