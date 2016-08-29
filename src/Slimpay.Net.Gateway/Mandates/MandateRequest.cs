using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Mandates
{
  /// <summary>
  /// A mandate. Only used when creating an order. This is an extended version of the mandate-representation,
  /// as it should include the resources which are related to the mandate, eg a signatory-representation
  /// and billing-address-representation.
  /// </summary>
  public class MandateRequest
  {
    [JsonProperty("signatory")]
    public MandateItemSignatory Signatory { get; set; }

    public override string ToString()
    {
      return string.Format("MandateRequest{signatory={0}}", Signatory);
    }
  }
}