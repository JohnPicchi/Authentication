using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.EditModels
{
  public class RegisterEditModel
  {
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    //[Remote(action: "VerifyEmail", controller: "Account")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Registration Code")]
    public string RegistrationCode { get; set; }
  }
}
