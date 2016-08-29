using System;
using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebits
{
  public class UpdateDirectDebitRequest : HalResource
  {
    [JsonIgnore]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("paymentReference")]
    public string PaymentReference { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("executionDate")]
    public DateTime ExecutionDate { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    public override string ToString()
    {
      return string.Format("UpdateDirectDebitRequest{amount={0}, paymentReference='{1}', executionDate={2}, label='{3}'}",
        Amount, PaymentReference, ExecutionDate, Label);
    }
  }
}