using System;
using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Documents
{
  /// <summary>
  /// Document resource.
  /// </summary>
  public class Document : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    [JsonProperty("timestamped")]
    public bool Timestamped { get; set; }

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("binaryContent")]
    public string BinaryContent { get; set; }

    public override string ToString()
    {
      return string.Format("Document{reference='{0}', timestamped={1}, timestamp={2}, dateCreated={3}, binaryContent='{4}'}",
          Reference, Timestamped, Timestamp, DateCreated, BinaryContent);
    }
  }
}