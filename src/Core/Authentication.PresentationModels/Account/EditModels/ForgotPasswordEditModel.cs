using System.ComponentModel.DataAnnotations;
using Authentication.Utilities.Helpers;

namespace Authentication.PresentationModels.Account.EditModels
{
  public class ForgotPasswordEditModel
  {
    [Required]
    [DataType(DataType.EmailAddress)]
    [MaxLength(Helper.MaxLength.Email, ErrorMessage = "Email cannot exceed 256 characters")]
    public string Email { get; set; }
  }
}
