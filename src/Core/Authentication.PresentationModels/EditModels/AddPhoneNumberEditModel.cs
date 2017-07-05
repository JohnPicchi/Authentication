using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.PresentationModels.EditModels
{
  public class AddPhoneNumberEditModel
  {
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
  }
}
