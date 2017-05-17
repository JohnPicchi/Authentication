using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using Authentication.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.EditModels
{
  public class RegisterEditModel
  {
    [Required]
    [Remote(action: "CheckAccountId", controller: "Account")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(Helper.MaxLength.Email, ErrorMessage = "Email address cannot exceed 256 characters")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MaxLength(Helper.MaxLength.Password, ErrorMessage = "Password cannot exceed 256 characters")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
  }
}
