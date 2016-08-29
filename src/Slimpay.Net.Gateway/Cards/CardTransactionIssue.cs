using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;

namespace Slimpay.Net.Gateway.Cards
{
  /// <summary>
  /// A card transaction issue represents an issue that might happen when executing a card transaction.
  /// </summary>
  public class CardTransactionIssue
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("rejectAmount")]
    public decimal RejectAmount { get; set; }

    [JsonProperty("rejectReason")]
    public string RejectReason { get; set; }

    [JsonProperty("returnReasonCode")]
    public string ReturnReasonCode { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("executionStatus")]
    public ExecutionStatus ExecutionStatus { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    public override string ToString()
    {
      return string.Format("CardTransactionIssue{id='{0}', rejectAmount={1}, rejectReason='{2}', returnReasonCode='{3}', executionStatus={4}, dateCreated='{5}'}",
        Id, RejectAmount, RejectReason, ReturnReasonCode, ExecutionStatus, DateCreated);
    }
  }
}