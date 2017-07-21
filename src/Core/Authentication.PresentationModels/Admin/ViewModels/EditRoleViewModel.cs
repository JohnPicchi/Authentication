using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class EditRoleViewModel
  {
    public EditRoleEditModel Role { get; set; }

    public AddRoleClaimEditModel RoleClaim { get; set; }

    public IList<RoleClaimViewModel> RoleClaims { get; set; }

    [Display(Name = "Date Created")]
    [DataType(DataType.Date)]
    public DateTime? DateCreated { get; set; }

    [Display(Name = "Date Updated")]
    [DataType(DataType.Date)]
    public DateTime? DateUpdated { get; set; }
  }
}