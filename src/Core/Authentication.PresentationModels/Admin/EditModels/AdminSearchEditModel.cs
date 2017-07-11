using System;

namespace Authentication.PresentationModels.Admin.EditModels
{
  [Flags]
  public enum SearchKind
  {
    User = 0,
    //Message = 1,
   // Claim = 2,
    Role = 4,
   // All = 255
  }

  public class AdminSearchEditModel
  {
    public string Query { get; set; }

    public SearchKind? Kind { get; set; }

    //Current page
    public int Page { get; set; }

    //Number of results per page
    public int Count { get; set; } = 25;
  }
}
