using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class EditUserViewModel : EditUserEditModel
  {
    public bool VerifiedPhoneNumber { get; set; }

    public bool VerifiedEmail { get; set; }

    [Display(Name = "Failed Login Attempts")]
    public int FailedAccessCount { get; set; }

    [Display(Name = "Last Login")]
    public DateTime LastLogin { get; set; }

    public IEnumerable<Claim> Claims { get; set; }

    [Display(Name = "Date Created")]
    [DataType(DataType.DateTime)]
    public DateTime DateCreated { get; set; }

    [Display(Name = "Date Updated")]
    [DataType(DataType.DateTime)]
    public DateTime DateUpdated { get; set; }
  }
}
