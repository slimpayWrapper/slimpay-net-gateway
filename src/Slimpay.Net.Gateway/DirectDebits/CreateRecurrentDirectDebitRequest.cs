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
  public class CreateRecurrentDirectDebitRequest : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("currency")]
    public CurrencyType? Currency { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("frequency")]
    public FrequencyType? Frequency { get; set; }

    [JsonProperty("maxSddNumber")]
    public int? MaxSddNumber { get; set; }

    [JsonProperty("activated")]
    public bool? Activated { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateFrom")]
    public DateTime? DateFrom { get; set; }

    [JsonProperty("creditor")]
    public CreditorRequest Creditor { get; set; }

    [JsonProperty("subscriber")]
    public Subscriber Subscriber { get; set; }

    public override string ToString()
    {
      return string.Format("RecurrentDirectDebit{reference='{0}', amount={1}, currency={2}, label='{3}', frequency={4}, maxSddNumber={5}, " +
        "activated={6}, dateFrom={7}, creditor={8}, subscriber={9}}",
        Reference, Amount, Currency, Label, Frequency, MaxSddNumber, Activated, DateFrom, Creditor, Subscriber);
    }
  }
}
