using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;

namespace Slimpay.Net.Gateway.Cards
{
  /// <summary>
  /// A card transaction representation.
  /// </summary>
  public class CardTransaction
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("executionDate")]
    public DateTime ExecutionDate { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("operation")]
    public OperationType Operation { get; set; }

    [JsonProperty("returnCode")]
    public string ReturnCode { get; set; }

    [JsonProperty("result")]
    public int? Result { get; set; }

    [JsonProperty("transactionId")]
    public string TransactionId { get; set; }

    [JsonProperty("reference")]
    public string Reference { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("executionStatus")]
    public ExecutionStatus ExecutionStatus { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    public override string ToString()
    {
      return string.Format("CardTransaction{id='{0}', amount={1}, executionDate={2}, operation={3}, returnCode='{4}', result={5}, transactionId='{6}', reference='{7}', executionStatus={8}, dateCreated={9}}",
        Id, Amount, ExecutionDate, Operation, ReturnCode, Result, TransactionId, Reference, ExecutionStatus, DateCreated);
    }
  }
}