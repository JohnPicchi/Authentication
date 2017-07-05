using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.PresentationModels.EditModels
{
  public class ConfirmPhoneNumberEditModel
  {
    [Required]
    public string Code { get; set; }
  }
}
