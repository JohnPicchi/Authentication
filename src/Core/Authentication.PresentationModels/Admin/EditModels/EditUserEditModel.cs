using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Authentication.PresentationModels.Account.EditModels;
using Authentication.User.Models;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class EditUserEditModel : AccountSettingsEditModel
  {
    [Display(Name = "Lockout End Date")]
    [DataType(DataType.DateTime)]
    public DateTime LockoutEndDate { get; set; } = DateTime.Now;

    [Display(Name = "Lock Account")]
    public bool LockAccount { get; set; }

    public EditUserAddressEditModel Address { get; set; } = new EditUserAddressEditModel();
  }
}