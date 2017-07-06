using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.PresentationModels.EditModels
{
  public class ConfirmPhoneNumberViewModel : ConfirmPhoneNumberEditModel
  {
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
  }
}