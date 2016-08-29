using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Orders
{
  /// <summary>
  /// A subscriber request.
  /// </summary>
  public class SubscriberRequest
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    public override string ToString()
    {
      return string.Format("SubscriberRequest{reference='{0}'}",
        Reference);
    }
  }
}