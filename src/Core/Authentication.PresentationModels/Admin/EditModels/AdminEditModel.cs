using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.Admin.ViewModels;

namespace Authentication.PresentationModels.Admin.EditModels
{
  public class AdminEditModel
  {
    public AddUserViewModel AddUser { get; set; } = new AddUserViewModel();

    public AddRoleViewModel AddRole { get; set; } = new AddRoleViewModel();
  }
}