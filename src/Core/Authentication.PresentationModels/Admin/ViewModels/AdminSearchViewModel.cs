using System;
using Authentication.PresentationModels.Admin.EditModels;

namespace Authentication.PresentationModels.Admin.ViewModels
{
  public class AdminSearchViewModel : AdminSearchEditModel
  {
    //Total number of results
    public int Total { get; set; }

    //Result DTO ?
  }

  public class AdminSearchResultViewModel
  {
    public Guid Id { get; set; }
  }
}
