using System.ComponentModel.DataAnnotations;
using Authentication.PresentationModels.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class AddRoleEditModel
  {
    [UniqueRoleName]
    [Remote(action: "VerifyRoleName", controller: "Admin")]
    [Required(ErrorMessage = "Role Name Required")]
    [Display(Name = "Role Name")]
    public string RoleName { get; set; }
  }
}
