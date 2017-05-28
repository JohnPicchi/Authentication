using System;
using Authentication.Domain;

namespace Authentication.Account.Models
{
  public class AccountClaim : Entity<Guid>
  {
    public string Type { get; set; }

    public string Value { get; set; }

    public string ValueType { get; set; }

    public string Issuer { get; set; }
  }
}
