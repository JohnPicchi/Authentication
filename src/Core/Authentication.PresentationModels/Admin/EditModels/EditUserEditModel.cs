using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Authentication.User.Models;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class EditUserEditModel
  {
    [Display(Name = "User Id")]
    public Guid UserId { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "E-Mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Display(Name = "Date Created")]
    [DataType(DataType.DateTime)]
    public DateTime DateCreated { get; set; }

    [Display(Name = "Date Updated")]
    [DataType(DataType.DateTime)]
    public DateTime DateUpdated { get; set; }

    [Display(Name = "Lockout End Date")]
    [DataType(DataType.DateTime)]
    public DateTime? LockoutEndDate { get; set; }

    public bool LockAccount { get; set; }

    public EditUserAddressEditModel Address { get; set; } = new EditUserAddressEditModel();
  }
}