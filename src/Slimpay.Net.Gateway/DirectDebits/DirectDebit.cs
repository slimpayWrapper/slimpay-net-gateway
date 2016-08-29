using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebits
{
  /// <summary>
  /// A direct debit representation. A direct debit is a payment which is initiated by a creditor to transfer money from a
  /// debtor account to his own bank account. A direct debit requires an authorization from the debtor.
  /// </summary>
  public class DirectDebit : HalResource
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("currency")]
    public CurrencyType? Currency { get; set; }

    [JsonProperty("paymentReference")]
    public string PaymentReference { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("executionDate")]
    public DateTime? ExecutionDate { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("executionStatus")]
    public ExecutionStatus? ExecutionStatus { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("sequenceType")]
    public SequenceType? SequenceType { get; set; }

    [JsonProperty("replayCount")]
    public int? ReplayCount { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateCreated")]
    public DateTime? DateCreated { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateBooked")]
    public DateTime? DateBooked { get; set; }

    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    [JsonProperty("dateValued")]
    public DateTime? DateValued { get; set; }


    public override string ToString()
    {
      return string.Format("DirectDebit{id='{0}', amount={1}, currency={2}, paymentReference='{3}', label='{4}', executionDate='{5}', executionStatus={6}, sequenceType={7}, " +
        "replayCount={8}, dateCreated={9}, dateBooked={10}, dateValued={11}}",
        Id, Amount, Currency, PaymentReference, Label, ExecutionDate, ExecutionStatus, SequenceType, ReplayCount, DateCreated, DateBooked, DateValued);
    }
  }
}