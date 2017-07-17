using System.ComponentModel.DataAnnotations;
using Authentication.PresentationModels.Account.EditModels;

namespace Authentication.PresentationModels.Account.ViewModels
{
  public class ConfirmPhoneNumberViewModel : ConfirmPhoneNumberEditModel
  {
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
  }
}