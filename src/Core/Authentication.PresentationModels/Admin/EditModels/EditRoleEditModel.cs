using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.PresentationModels.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public abstract class BaseRoleEditModel
  {
    [HiddenInput]
    [Display(Name = "Role Id")]
    public Guid RoleId { get; set; }

    public abstract string RoleName { get; set; }
  }

  public class EditRoleEditModel : BaseRoleEditModel
  {
    [UniqueRoleName]
    [Required(ErrorMessage = "Role name is required")]
    [Display(Name = "Role Name")]
    public override string RoleName { get; set; }
  }
}
