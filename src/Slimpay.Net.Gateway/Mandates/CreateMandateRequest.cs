using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;
using Slimpay.Net.Gateway.Subscribers;

namespace Slimpay.Net.Gateway.Mandates
{
  public class CreateMandateRequest : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    [Obsolete("Use Reference instead")]
    [JsonProperty("rum")]
    public string Rum { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("standard")]
    public Standard? Standard { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("paymentScheme")]
    public PaymentScheme? PaymentScheme { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("createSequenceType")]
    public SequenceType? CreateSequenceType { get; set; }

    [JsonProperty("dateSigned")]
    [JsonConverter(typeof(SlimpayDateTimeConverter))]
    public DateTime? DateSigned { get; set; }

    [JsonProperty("creditor")]
    public Creditor Creditor { get; set; }

    [JsonProperty("subscriber")]
    public Subscriber Subscriber { get; set; }

    [JsonProperty("signatory")]
    public MandateItemSignatory Signatory { get; set; }

    public override string ToString()
    {
      return
        string.Format(
          "CreateMandate{ reference={0}, rum={1}, standard={2}, paymentScheme={3}, createSequenceType={4},  dateSigned={5}, creditor={6}, subscriber={7}, signatory={8}}",
          Reference, Rum, Standard, PaymentScheme, CreateSequenceType, DateSigned, Creditor, Subscriber, Signatory);
    }
  }
}
