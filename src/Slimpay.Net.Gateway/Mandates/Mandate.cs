using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Json.Converters;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Mandates
{
  public class Mandate : HalResource
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("reference")]
    public string Reference { get; set; }

    [Obsolete("Use Reference instead")]
    [JsonProperty("rum")]
    public string Rum { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("state")]
    public MandateState? State { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("standard")]
    public Standard? Standard { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("paymentScheme")]
    public PaymentScheme? PaymentScheme { get; set; }

    [JsonProperty("initialScore")]
    public int InitialScore { get; set; }

    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("sequenceType")]
    public SequenceType? SequenceType { get; set; }

    //todo: what to do  with different available values?
    [JsonConverter(typeof (StringEnumConverter))]
    [JsonProperty("createdSequenceType")]
    public SequenceType? CreatedSequenceType { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("dateRevoked")]
    public DateTime DateRevoked { get; set; }

    [JsonProperty("dateSigned")]
    public DateTime DateSigned { get; set; }

    public override string ToString()
    {
      return
        string.Format(
          "Mandate{id={0},reference={1}, rum={2}, state={3}, standard={4}, paymentScheme={5}, initialScore={6}, sequenceType={7}" +
          " createdSequenceType={8}, dateCreated={9}, dateRevoked={10}, dateSigned={11} }",
         Id, Reference, Rum, State, Standard,PaymentScheme, InitialScore, SequenceType, CreatedSequenceType, DateCreated, DateRevoked, DateSigned);
    }
  }
}
