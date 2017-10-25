using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Authentication.Utilities.Helpers;

namespace Authentication.PresentationModels.Account.EditModels
{
  public class AccountSettingsEditModel
  {
    [Display(Name = "User Id")]
    public Guid UserId { get; set; }

    [MaxLength(Helper.MaxLength.FirstName, ErrorMessage = "Input cannot exceed 128 characters")]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [MaxLength(Helper.MaxLength.LastName, ErrorMessage = "Input cannot exceed 128 characters")]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [Display(Name = "E-Mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "E-Mail Address Required")]
    public string Email { get; set; }

    [DataType(DataType.PhoneNumber)]
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    [DisplayName("Enable Multi-Factor Authentication")]
    public bool EnableMultiFactorAuth { get; set; }
  }
}