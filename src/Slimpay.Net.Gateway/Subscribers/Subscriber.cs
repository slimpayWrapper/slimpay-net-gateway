using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Subscribers
{
  /// <summary>
  /// Subscriber resource.
  /// </summary>
  public class Subscriber : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    public override string ToString()
    {
      return string.Format("Subscriber{reference='{0}'}",
        Reference);
    }
  }
}