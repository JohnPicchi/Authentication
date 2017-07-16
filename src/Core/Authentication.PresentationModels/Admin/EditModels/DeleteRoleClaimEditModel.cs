using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class DeleteRoleClaimEditModel
  {
    public int Id { get; set; }

    public Guid RoleId { get; set; }
  }
}
