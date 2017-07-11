using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class EditRoleEditModel
  {
    [HiddenInput]
    public Guid RoleId { get; set; }

    [Required(ErrorMessage = "Role name required")]
    [Display(Name = "Role Name")]
    public string RoleName { get; set; }

    public RoleClaimEditModel RoleClaim { get; set; }
  }

  public class RoleClaimEditModel
  {
    [HiddenInput]
    public string Id { get; set; }

    [Required(ErrorMessage = "Claim type is required")]
    [Display(Name = "Claim Type")]
    public string ClaimType { get; set; }

    [Required (ErrorMessage = "Claim value is required")]
    [Display(Name = "Claim Value")]
    public string ClaimValue { get; set; }
  }
}
