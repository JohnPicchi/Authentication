using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Account.Models
{
  public class Token
  {
    public int Kind { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime ExpirationTime { get; set; }

    public string Value { get; set; }
  }
}
