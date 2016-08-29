using System;
using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.DirectDebitIssues
{
  /// <summary>
  /// Direct Debit Issue resource
  /// </summary>
  public class DirectDebitIssueRequest : HalResource
  {
    [JsonProperty("creditorReference")]
    public string CreditorReference { get; set; }

    [JsonProperty("entityReference")]
    public Creditor EntityReference { get; set; }

    [JsonProperty("subscriberReference")]
    public string SubscriberReference { get; set; }

    [JsonProperty("currency")]
    public CurrencyType Currency { get; set; }

    [JsonProperty("executionStatus")]
    public ExecutionStatus ExecutionStatus { get; set; }

    [JsonProperty("dateCreatedBefore")]
    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    public DateTime DateCreatedBefore { get; set; }

    [JsonProperty("dateCreatedAfter")]
    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    public DateTime DateCreatedAfter { get; set; }

    public override string ToString()
    {
      return
        string.Format("DirectDebitIssueRequest{creditorReference={0}, entityReference={1}, subscriberReference={2}, currency={3}, executionStatus={4}, " +
          "dateCreatedBefore={5}, dateCreatedAfter={6} }",
          CreditorReference, EntityReference, SubscriberReference, Currency, ExecutionStatus, DateCreatedBefore, DateCreatedAfter);
    }
  }
}
