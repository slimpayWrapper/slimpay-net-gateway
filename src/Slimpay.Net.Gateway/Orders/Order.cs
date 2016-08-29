using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Orders
{
  /// <summary>
  /// Order resource.
  /// </summary>
  public class Order : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("paymentScheme")]
    public PaymentScheme? PaymentScheme { get; set; }

    [JsonProperty("locale")]
    public string Locale { get; set; }

    [JsonProperty("started")]
    public bool Started { get; set; }

    [JsonProperty("dateClosed")]
    public DateTime DateClosed { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("dateModified")]
    public DateTime DateModified { get; set; }

    [JsonProperty("pingAfter")]
    public DateTime PingAfter { get; set; }

    [JsonProperty("mandateReused")]
    public bool MandateReused { get; set; }

    public override string ToString()
    {
      return string.Format("Order{reference='{0}', state='{1}', started={2}, dateClosed={3}, dateCreated={4}, dateModified={5}, pingAfter={6}, mandateReused={7}}",
        Reference, State, Started, DateClosed, DateCreated, DateModified, PingAfter, MandateReused);
    }
  }
}