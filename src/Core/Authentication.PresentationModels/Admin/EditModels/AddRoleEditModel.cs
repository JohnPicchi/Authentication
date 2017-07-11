using System.ComponentModel.DataAnnotations;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class AddRoleEditModel
  {
    [Required(ErrorMessage = "Role Name Required")]
    [Display(Name = "Role Name")]
    public string RoleName { get; set; }
  }
}
