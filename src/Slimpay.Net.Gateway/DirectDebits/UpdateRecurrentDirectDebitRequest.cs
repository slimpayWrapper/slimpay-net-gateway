using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebits
{
  public class UpdateRecurrentDirectDebitRequest : HalResource
  {
    [JsonIgnore]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    public override string ToString()
    {
      return string.Format("UpdateDirectDebitRequest{amount={0}, label='{1}'}",
        Amount, Label);
    }
  }
}