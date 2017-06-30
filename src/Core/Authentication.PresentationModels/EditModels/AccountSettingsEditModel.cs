using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.Utilities.Helpers;

namespace Authentication.PresentationModels.EditModels
{
  public class AccountSettingsEditModel
  {
    [MaxLength(Helper.MaxLength.FirstName, ErrorMessage = "Input cannot exceed 128 characters")]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [MaxLength(Helper.MaxLength.LastName, ErrorMessage = "Input cannot exceed 128 characters")]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    [MaxLength(Helper.MaxLength.AddressLine1, ErrorMessage = "Input cannot exceed 256 characters")]
    [DisplayName("Address")]
    public string AddressLine1 { get; set; }

    [MaxLength(Helper.MaxLength.AddressLine1, ErrorMessage = "Input cannot exceed 256 characters")]
    public string AddressLine2 { get; set; }

    [MaxLength(Helper.MaxLength.Country, ErrorMessage = "Input cannot exceed 256 characters")]
    public string Country { get; set; }

    [MaxLength(Helper.MaxLength.StateProvinceRegion, ErrorMessage = "Input cannot exceed 256 characters")]
    [DisplayName("State / Province / Region")]
    public string StateProvinceRegion { get; set; }

    [DataType(DataType.PostalCode)]
    [MaxLength(Helper.MaxLength.ZipCode, ErrorMessage = "Input cannot exceed 64 characters")]
    [DisplayName("Postal Code")]
    public string PostalCode { get; set; }

    [DisplayName("Two Factor Authentication")]
    public bool TwoFactorEnabled { get; set; }
  }
}
