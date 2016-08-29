using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebitIssues
{
  /// <summary>
  /// A direct debit issue representation. A direct debit issue, also known as R-Transaction, is an issue that can happen when executing a direct debit.
  /// </summary>
  /// <seealso cref="Slimpay.Net.Gateway.Core.Models.HalResource" />
  public class DirectDebitIssue : HalResource
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("rejectAmount")]
    public decimal RejectAmount { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("currency")]
    public CurrencyType Currency { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("executionStatus")]
    public ExecutionStatus ExecutionStatus { get; set; }

    [JsonProperty("rejectReason")]
    public string RejectReason { get; set; }

    [JsonProperty("returnReasonCode")]
    public string ReturnReasonCode { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("dateBooked")]
    public DateTime DateBooked { get; set; }

    [JsonProperty("dateValued")]
    public DateTime DateValued { get; set; }

    public override string ToString()
    {
      return string.Format("DirectDebitIssueRequest{id={0}, rejectAmount={1}, currency={2}, executionStatus={3}, rejectReason={4}, returnReasonCode={5}, Type={6}," +
                     " dateCreated={7}, dateBooked={8}, dateValued={9} }",
      Id, RejectAmount, Currency, ExecutionStatus, RejectReason, ReturnReasonCode, Type, DateCreated, DateBooked, DateValued);
    }
  }
}
