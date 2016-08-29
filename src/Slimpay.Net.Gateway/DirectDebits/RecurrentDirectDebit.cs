using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebits
{
  /// <summary>
  /// A recurrent direct debit representation. A recurrent direct debit is a payment plan to schedule the execution of direct
  /// debits at regular intervals of time.
  /// </summary>
  public class RecurrentDirectDebit : HalResource
  {
    [JsonProperty("id")]
    public string Id { get; set; }

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
    public FrequencyType Frequency { get; set;}

    [JsonProperty("maxSddNumber")]
    public int? MaxSddNumber { get; set; }

    [JsonProperty("sddNumber")]
    public int? SddNumber { get; set; }

    [JsonProperty("activated")]
    public bool? Activated { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime? DateCreated { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateFrom")]
    public DateTime? DateFrom { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateNext")]
    public DateTime? DateNext { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateDisabled")]
    public DateTime? DateDisabled { get; set; }

    public override string ToString()
    {
      return string.Format("RecurrentDirectDebit{id='{0}', reference='{1}', amount={2}, currency={3}, label='{4}', frequency={5}, maxSddNumber={6}, sddNumber={7}, " +
        "activated={8}, dateCreated={9}, dateFrom={10}, dateNext={11}, dateDisabled={12}",
        Id, Reference, Amount, Currency, Label, Frequency, MaxSddNumber, SddNumber, Activated, DateCreated, DateFrom, DateNext, DateDisabled);
    }
  }
}