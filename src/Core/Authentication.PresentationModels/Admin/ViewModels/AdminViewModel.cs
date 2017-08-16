using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class AdminViewModel
  {
    public AddUserEditModel AddUser { get; set; } = new AddUserEditModel();
  }
}
