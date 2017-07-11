using System.ComponentModel.DataAnnotations;

namespace Authentication.PresentationModels.Account.EditModels
{
  public class AddPhoneNumberEditModel
  {
    [Required(ErrorMessage = "Phone Number is required")]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
  }
}
