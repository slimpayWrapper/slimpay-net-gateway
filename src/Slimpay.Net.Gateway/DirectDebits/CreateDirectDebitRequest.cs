using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;
using Slimpay.Net.Gateway.Subscribers;

namespace Slimpay.Net.Gateway.DirectDebits
{
  public class CreateDirectDebitRequest : HalResource
  {
    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("currency")]
    public CurrencyType? Currency { get; set; }

    [JsonProperty("paymentReference")]
    public string PaymentReference { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("executionDate")]
    public DateTime? ExecutionDate { get; set; }

    [JsonProperty("creditor")]
    public CreditorRequest Creditor { get; set; }

    [JsonProperty("subscriber")]
    public Subscriber Subscriber { get; set; }

    [JsonProperty("mandate")]
    public DirectDebitMandate Mandate { get; set; }

    public override string ToString()
    {
      return string.Format("CreateDirectDebitRequest{amount={0}, currency={1}, paymentReference='{2}', label='{3}', executionDate='{4}', " +
        "creditor={5}, subscriber={6}, mandate={7}}",
        Amount, Currency, PaymentReference, Label, ExecutionDate, Creditor, Subscriber, Mandate);
    }
  }
}
