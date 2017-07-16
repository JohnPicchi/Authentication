using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class EditRoleClaimEditModel
  {
    public int Id { get; set; }

    public Guid RoleId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }
  }
}