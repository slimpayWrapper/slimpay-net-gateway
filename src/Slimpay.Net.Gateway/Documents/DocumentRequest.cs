using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.Documents
{
  /// <summary>
  /// Document request.
  /// </summary>
  public class DocumentRequest : HalResource
  {
    [JsonProperty("creditor")]
    public CreditorRequest Creditor { get; set; }

    [JsonProperty("timestamped")]
    public bool Timestamped { get; set; }

    [JsonProperty("binaryContent")]
    public BinaryContentRequest BinaryContent { get; set; }

    public override string ToString()
    {
      return string.Format("DocumentRequest{creditorRequest={0}, timestamped={1}, binaryContent='{2}'}",
        Creditor, Timestamped, BinaryContent);
    }
  }
}