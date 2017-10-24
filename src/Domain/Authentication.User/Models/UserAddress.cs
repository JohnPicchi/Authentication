using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Common;

namespace Authentication.User.Models
{
  public class UserAddress : TrackedPersistedEntity<Guid>
  {
    public User User { get; set; }

    public Guid UserId { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string PostalCode { get; set; }

    public string StateProvinceRegion { get; set; }

    public string Country { get; set; }
  }
}