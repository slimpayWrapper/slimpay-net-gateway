using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;
using Slimpay.Net.Gateway.Mandates;
using Slimpay.Net.Gateway.Subscribers;

namespace Slimpay.Net.Gateway.CreditTransfers
{
  /// <summary>
  /// Request for Create a credit transfer.
  /// </summary>
  /// <seealso cref="Slimpay.Net.Gateway.Core.Models.HalResource" />
  public class CreditTransferRequest : HalResource
  {
    [JsonProperty("creditor")]
    public Creditor Creditor { get; set; }

    [JsonProperty("subscriber")]
    public Subscriber Subscriber { get; set; }

    [JsonProperty("mandate")]
    public Mandate Mandate { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("currency")]
    public CurrencyType? Currency { get; set; }

    [JsonProperty("paymentReference")]
    public string PaymentReference { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("executionDate")]
    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    public DateTime? ExecutionDate { get; set; }

    public override string ToString()
    {
      return string.Format("CreditTransferRequest{creditor={0}, subscriber={1}, mandate={2}, label={3}, currency={4}, paymentReference={5}, amount={6}," +
                           " executionDate={7}}",
        Creditor, Subscriber, Mandate, Label, Currency, PaymentReference, Amount, ExecutionDate);
    }
  }
}
