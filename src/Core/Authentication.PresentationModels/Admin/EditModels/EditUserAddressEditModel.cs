using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class EditUserAddressEditModel
  {
    [Display(Name = "Address Line 1")]
    public string AddressLine1 { get; set; }

    [Display(Name = "Address Line 2")]
    public string AddressLine2 { get; set; }

    [DataType(DataType.PostalCode)]
    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; }

    [Display(Name = "State/Province/Region")]
    public string StateProvinceRegion { get; set; }

    public string Country { get; set; }
  }
}