﻿using System.ComponentModel.DataAnnotations;
using Authentication.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.PresentationModels.Account.EditModels
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

    public bool RememberLogin { get; set; } = true;

    [HiddenInput]
    public string ReturnUrl { get; set; }
  }
}