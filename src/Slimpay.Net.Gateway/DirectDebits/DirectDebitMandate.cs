using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebits
{
  public class DirectDebitMandate : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    public override string ToString()
    {
      return string.Format("DirectDebitMandate{reference='{0}'}",
        Reference);
    }
  }
}