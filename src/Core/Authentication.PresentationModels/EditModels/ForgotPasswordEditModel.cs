using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.Utilities.Helpers;

namespace Authentication.PresentationModels.EditModels
{
  public class ForgotPasswordEditModel
  {
    [Required]
    [DataType(DataType.EmailAddress)]
    [MaxLength(Helper.MaxLength.Email, ErrorMessage = "Input cannot exceed 256 characters")]
    public string Email { get; set; }
  }
}
