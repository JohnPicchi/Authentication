using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.User.Models
{
  public class UserAddress
  {
    //
    // Summary:
    //  Gets or sets the primary key of the address
    public Guid Id { get; set; }
    //
    // Summary:
    //    A foriegn key, associating a user address to a specific user
    public Guid UserId { get; set; }
    //
    // Summary:
    //    A navigation reference to the user who this address belongs
    public User User { get; set; }
    //
    // Summary:
    //    Street & number, P.O box, c/o.
    public string AddressLine1 { get; set; }
    //
    // Summary:
    //    Apartment, suite, unit, building, floor, etc.
    public string AddressLine2 { get; set; }
    //
    // Summary:
    //    Gets or sets the state / province / region
    public string StateProvinceRegion { get; set; }
    //
    // Summary:
    //    Gets or sets the zip code
    public string PostalCode { get; set; }
    //
    // Summary:
    //    Gets or sets the country
    public string Country { get; set; }
  }
}
