using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.CreditTransfers
{
  /// <summary>
  /// A credit transfer is a payment initiated by a debtor from his bank account to another bank account
  /// </summary>
  /// <seealso cref="Slimpay.Net.Gateway.Core.Models.HalResource" />
  public class CreditTransfer : HalResource
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("currency")]
    public CurrencyType Currency { get; set; }

    [JsonProperty("paymentReference")]
    public string PaymentReference { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("executionStatus")]
    public ExecutionStatus ExecutionStatus { get; set; }

    [JsonProperty("executionDate")]
    public DateTime ExecutionDate { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("dateBooked")]
    public DateTime DateBooked { get; set; }

    [JsonProperty("dateValued")]
    public DateTime DateValued { get; set; }

    public override string ToString()
    {
      return string.Format("CreditTransfer{id={0}, amount={1}, currency={2}, paymentReference={3}, label={4}, executionStatus={5}, executionDate={6}," +
                           " dateCreated={7}, dateBooked={8}, dateValued={9} }",
        Id, Amount, Currency, PaymentReference, Label, ExecutionStatus, ExecutionDate, DateCreated, DateBooked, DateValued);
    }
  }
}
