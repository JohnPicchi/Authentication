using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class AddRoleClaimEditModel
  {
    [HiddenInput]
    [Display(Name = "Role Id")]
    public Guid RoleId { get; set; }

    [Required(ErrorMessage = "Claim type is required")]
    [Display(Name = "Claim Type")]
    public string Type { get; set; }

    [Required(ErrorMessage = "Claim value is required")]
    [Display(Name = "Claim Value")]
    public string Value { get; set; }
  }
}
