using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.PresentationModels.EditModels
{
  public class ConfirmPhoneNumberEditModel
  {
    [Required]
    [Display(Name = "Security Code")]
    public string SecurityCode { get; set; }
  }
}
