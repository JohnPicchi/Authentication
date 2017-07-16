using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.PresentationModels.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class EditRoleEditModel
  {
    [HiddenInput]
    [Display(Name = "Role Id")]
    public Guid Id { get; set; }

    [UniqueRoleName]
    [Required(ErrorMessage = "Role name is required")]
    [Display(Name = "Role Name")]
    public string Name { get; set; }
  }
}
