using System.ComponentModel.DataAnnotations;

namespace Authentication.PresentationModels.Account.EditModels
{
  public class ConfirmPhoneNumberEditModel
  {
    [Required]
    [Display(Name = "Security Code")]
    public string SecurityCode { get; set; }
  }
}
