﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.Utilities.Helpers;

namespace Authentication.PresentationModels.EditModels
{
  public class LoginEditModel
  {
    [Required(ErrorMessage = "Email required")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(Helper.MaxLength.Email, ErrorMessage = "Email address cannot exceed 256 characters")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password required")]
    [DataType(DataType.Password)]
    [MaxLength(Helper.MaxLength.Password, ErrorMessage = "Password cannot exceed 256 characters")]
    public string Password { get; set; }
  }
}