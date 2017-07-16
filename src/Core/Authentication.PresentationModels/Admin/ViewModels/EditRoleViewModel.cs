using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class EditRoleViewModel
  {
    public EditRoleEditModel Role { get; set; } = new EditRoleEditModel();

    public AddRoleClaimEditModel RoleClaim { get; set; } = new AddRoleClaimEditModel();

    public IEnumerable<RoleClaimViewModel> RoleClaims { get; set; } = new List<RoleClaimViewModel>();

    [Display(Name = "Date Created")]
    [DataType(DataType.Date)]
    public DateTime? DateCreated { get; set; }

    [Display(Name = "Date Updated")]
    [DataType(DataType.Date)]
    public DateTime? DateUpdated { get; set; }

    public Guid RoleId
    {
      get => Role.Id;
      set => (Role.Id, RoleClaim.RoleId) = (value, value);
    }
  }
}