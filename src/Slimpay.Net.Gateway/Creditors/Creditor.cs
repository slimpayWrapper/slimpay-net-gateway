using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Creditors
{
  /// <summary>
  /// A creditor representation. A creditor is, most of the time, a merchant.
  /// </summary>
  public class Creditor : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    public override string ToString()
    {
      return string.Format("Creditor{reference='{0}'}", Reference);
    }
  }
}