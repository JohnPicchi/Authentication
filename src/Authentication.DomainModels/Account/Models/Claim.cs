namespace Authentication.Domain.Account.Models
{
  public class Claim
  {
    public string Type { get; set; }

    public string Value { get; set; }

    public string ValueType { get; set; }

    public string Issuer { get; set; }
  }
}
