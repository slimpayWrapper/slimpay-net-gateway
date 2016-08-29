using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Addresses
{
  /// <summary>
  /// A postal address representation. A postal address identifies a geographical location.
  /// </summary>
  public class Address
  {
    [JsonProperty("street1")]
    public string Street1 { get; set; }

    [JsonProperty("street2")]
    public string Street2 { get; set; }

    [JsonProperty("postalCode")]
    public string PostalCode { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    public override string ToString()
    {
      return string.Format("Address{street1='{0}', street2='{1}', postalCode='{2}', city='{3}', country='{4}'}",
        Street1, Street2, PostalCode, City, Country);
    }
  }
}